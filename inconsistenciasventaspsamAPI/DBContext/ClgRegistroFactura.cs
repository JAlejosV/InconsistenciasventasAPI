using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class ClgRegistroFactura
    {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public string Moneda { get; set; }
        public decimal? MontoTotal { get; set; }
        public string VtrmvcCodfor { get; set; }
        public int VtrmvcNrofor { get; set; }
        public string VtrmvcCodapl { get; set; }
        public int VtrmvcNroapl { get; set; }
        public decimal? MontoPagado { get; set; }
        public decimal? MontoPendiente { get; set; }
    }
}
