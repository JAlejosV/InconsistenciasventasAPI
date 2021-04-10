using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class LimiteCredito
    {
        public string ShortNameLc { get; set; }
        public decimal? MontoLimiteCredito { get; set; }
        public string MonedaCredito { get; set; }
    }
}
