using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class DocumentoDetalleIntegral
    {
        public long IdDocumentoDetalleIntegral { get; set; }
        public long IdCodigoDocumentoDetalle { get; set; }
        public int ItemDetalle { get; set; }
        public int ItemIntegral { get; set; }
        public string CodigoProducto { get; set; }
        public string CentroBeneficio { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public bool? AfectoIgv { get; set; }
        public string TipoRecurso { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }

        public virtual DocumentoDetalle IdCodigoDocumentoDetalleNavigation { get; set; }
    }
}
