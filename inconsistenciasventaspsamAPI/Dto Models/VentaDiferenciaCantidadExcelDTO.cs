using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inconsistenciasventaspsamAPI.Dto_Models
{
    public class VentaDiferenciaCantidadExcelDTO
    {
        public string Periodo { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public string Estado { get; set; }
    }
}
