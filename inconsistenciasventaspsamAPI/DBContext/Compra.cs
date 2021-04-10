using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class Compra
    {
        public Compra()
        {
            CompraDetalles = new HashSet<CompraDetalle>();
            CompraDocumentoRefs = new HashSet<CompraDocumentoRef>();
        }

        public int IdCompra { get; set; }
        public string Documento { get; set; }
        public string Proveedor { get; set; }
        public string DocumentoProveedor { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string TipoMoneda { get; set; }
        public string MotivoNota { get; set; }
        public string NumSerie { get; set; }
        public long NumDocumento { get; set; }
        public DateTime FechaEmision { get; set; }
        public string FormaPago { get; set; }
        public decimal Isc { get; set; }
        public decimal Igv { get; set; }
        public decimal DescuentoGlobal { get; set; }
        public decimal? TotalDescuento { get; set; }
        public decimal ValorAfecto { get; set; }
        public decimal ValorInafecto { get; set; }
        public decimal ValorExonerado { get; set; }
        public decimal ValorRegalo { get; set; }
        public decimal? ValorDonacion { get; set; }
        public decimal ImporteSubTotal { get; set; }
        public decimal? ImportePercepcion { get; set; }
        public decimal ImporteTotal { get; set; }
        public string ImporteTotalTexto { get; set; }
        public string EstadoSunat { get; set; }
        public bool EstaActivo { get; set; }
        public string Observaciones { get; set; }
        public bool FlagRegistroManual { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public decimal Detraccion { get; set; }
        public string UsuarioAprobador { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string OrdenCompra { get; set; }
        public decimal? PorcDescGlobal { get; set; }
        public string CodigoOperacion { get; set; }
        public bool? FlagOfisis { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string CodigoDetraccion { get; set; }

        public virtual ICollection<CompraDetalle> CompraDetalles { get; set; }
        public virtual ICollection<CompraDocumentoRef> CompraDocumentoRefs { get; set; }
    }
}
