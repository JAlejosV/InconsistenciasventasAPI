using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class TarifaDetraccion
    {
        public long Id { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreArticulo { get; set; }
        public string CodigoDetraccion { get; set; }
        public int? PorcentajeDetraccion { get; set; }
        public decimal? TopeMinimoSoles { get; set; }
        public decimal? TopeMinimoDolares { get; set; }
        public string CentroBeneficio { get; set; }
    }
}
