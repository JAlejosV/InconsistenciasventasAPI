using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class ClgFactura
    {
        public long Id { get; set; }
        public string NumeroDocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ShortNameCliente { get; set; }
        public string NombreSolidario { get; set; }
        public string Concatenado { get; set; }
        public string ShortNameLc { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string Moneda { get; set; }
        public decimal? MontoTotal { get; set; }
        public decimal? MontoDeuda { get; set; }
        public decimal? MontoPagado { get; set; }
        public string EstadoPagado { get; set; }
        public int? Vencido { get; set; }
        public int? DiasVencidos { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string NumeroDocumentoSolidario { get; set; }
        public long? IdCodigoDocumento { get; set; }
    }
}
