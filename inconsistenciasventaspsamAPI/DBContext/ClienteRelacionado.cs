using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class ClienteRelacionado
    {
        public long IdClienteRelacionado { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreCliente { get; set; }
        public bool? EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }
    }
}
