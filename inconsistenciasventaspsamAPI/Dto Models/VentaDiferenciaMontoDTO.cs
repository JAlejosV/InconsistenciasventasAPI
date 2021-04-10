using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inconsistenciasventaspsamAPI.Dto_Models
{
    public class VentaDiferenciaMontoDTO
    {
        public string Periodo { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public decimal MontoBDI { get; set; }
        public decimal MontoOfisis { get; set; }
        public decimal MontoDiferencia { get; set; }
        public string TipoError { get; set; }
    }
}
