using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class CompraDetalle
    {
        public int IdCompra { get; set; }
        public short Correlativo { get; set; }
        public string CodigoSunat { get; set; }
        public string Articulo { get; set; }
        public string Unidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? ValorVentaBruto { get; set; }
        public short? FlagDescuento { get; set; }
        public decimal? Descuento { get; set; }
        public decimal SubTotal { get; set; }
        public decimal? Isc { get; set; }
        public decimal? Igv { get; set; }
        public bool EstaActivo { get; set; }
        public string Observaciones { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal? PorcDescuento { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
    }
}
