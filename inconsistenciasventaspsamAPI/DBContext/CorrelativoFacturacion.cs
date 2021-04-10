using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class CorrelativoFacturacion
    {
        public long Id { get; set; }
        public string NombreTipoDocumento { get; set; }
        public string Serie { get; set; }
        public int? CodigoDocumento { get; set; }
        public int? Correlativo { get; set; }
    }
}
