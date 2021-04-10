using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using inconsistenciasventaspsamAPI.DBContext;
using inconsistenciasventaspsamAPI.Dto_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace inconsistenciasventaspsamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuecosFacturacionController : ControllerBase
    {
        private readonly InterfacesDBContext interfacesDB;
        private readonly IConfiguration config;
        public HuecosFacturacionController(InterfacesDBContext _interfacesDB, IConfiguration _config)
        {
            interfacesDB = _interfacesDB;
            config = _config;
        }

      
        // GET: api/<HuecosFacturacionController>
        [HttpGet]
        public IActionResult Get(bool EnvioCorreo)
        {
            var listaInconsistencias = interfacesDB.Set<HuecoFacturacionDTO>().FromSqlRaw($"exec USP_LISTA_HUECOS_FACTURACION").ToList();
            var envio = false;
            if (EnvioCorreo && listaInconsistencias.Count > 0)
            {
                //Crear archivo excel
                var stream = new MemoryStream();
                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Inconsistencias");
                    workSheet.Cells.LoadFromCollection(listaInconsistencias, true);
                    package.Save();
                }
                stream.Position = 0;
                var archivoExcel = stream.ToArray();
                string excelName = string.Format("InconsistenciasHuecosFacturacion-{0}.xlsx", DateTime.Now.ToString("yyyyMMddHHmmssfff"));

                //Enviar Correo
                Correo correo = new Correo();

                correo.CorreoEmisor.Mail = config.GetValue<string>("EnvioLogCorreo:CorreoEnvio:Mail");
                correo.CorreoEmisor.NameMail = config.GetValue<string>("EnvioLogCorreo:CorreoEnvio:NameMail");
                correo.CorreoEmisor.Password = config.GetValue<string>("EnvioLogCorreo:CorreoEnvio:Password");

                var CorreoDefectoPara = config.GetSection("EnvioLogCorreo:CorreoDefectoPara").Get<List<string>>();

                if (CorreoDefectoPara.Count > 0)
                {
                    foreach (var correoPara in CorreoDefectoPara)
                    {
                        correo.CorreosPara.Add(new StructMail
                        {
                            Mail = correoPara,
                            NameMail = string.Empty
                        });
                    }
                }

                var ConCopia = config.GetSection("EnvioLogCorreo:ConCopia").Get<List<string>>();
                if (ConCopia.Count > 0)
                {
                    foreach (var CorreoCC in ConCopia)
                    {
                        try
                        {
                            correo.CorreosCC.Add(new StructMail
                            {
                                Mail = CorreoCC,
                                NameMail = string.Empty
                            }
                            );
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }

                correo.Adjuntos.Add(new Adjunto
                {
                    archivo = archivoExcel,
                    nombreArchivo = excelName
                });

                try
                {
                    correo.Asunto = $"Inconsistencias Huecos de Facturacion";

                    string cuerpo = "Existen huecos de facturacion, en el excel adjunto se detallan los documentos.";

                    Helpers.Helpers.ConstruirCorreoError(correo, cuerpo);


                    envio = Helpers.Helpers.EnviarCorreoElectronico(correo, true);
                }
                catch (Exception ex)
                {

                }
            }

            return Ok(new
            {
                listaInconsistencias,
                correo = envio
            });
        }


    }
}
