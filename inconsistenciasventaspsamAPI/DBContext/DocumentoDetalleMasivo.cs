using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class DocumentoDetalleMasivo
    {
        public long IdCodigoDocumentoDetalle { get; set; }
        public long IdCodigoDocumento { get; set; }
        public string IdHelm { get; set; }
        public string NombreArticulo { get; set; }
        public int? ItemDetalle { get; set; }
        public string NombreUnidadMedida { get; set; }
        public string SiglaUnidadMedida { get; set; }
        public string UnidadMedidaSunat { get; set; }
        public string TipoProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string TipoConcepto { get; set; }
        public string CodigoConcepto { get; set; }
        public string CuentaContableProducto { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public byte? TipoPrecio { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? SubTotal { get; set; }
        public string CodigoArticulo { get; set; }
        public bool? EsDescuento { get; set; }
        public decimal? MontoIsc { get; set; }
        public decimal? TasaIsc { get; set; }
        public decimal? MontoBruto { get; set; }
        public decimal? MontoIgv { get; set; }
        public byte? TipoIsc { get; set; }
        public decimal? PorcentajePercepcionArticulo { get; set; }
        public decimal? MontoMinimoConsumidorFinal { get; set; }
        public byte? TipoPercepcion { get; set; }
        public decimal? PorcentajePercepcionVenta { get; set; }
        public decimal? ImportePercepcion { get; set; }
        public bool? FlagRecargo { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
    }
}
