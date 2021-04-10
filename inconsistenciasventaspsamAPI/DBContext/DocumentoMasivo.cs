using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class DocumentoMasivo
    {
        public long IdCodigoDocumento { get; set; }
        public string IdHelm { get; set; }
        public int? CodigoDocumento { get; set; }
        public string NombreCliente { get; set; }
        public int? CodigoDocumentoCliente { get; set; }
        public string NumeroDocumentoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string NombreSolidario { get; set; }
        public string NombreNave { get; set; }
        public decimal? Trb { get; set; }
        public decimal? Eslora { get; set; }
        public int? CodigoMoneda { get; set; }
        public string NombreMotivoNcNd { get; set; }
        public string CodigoSunatNcNd { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime? FechaEmision { get; set; }
        public decimal? TipoCambio { get; set; }
        public string Glosa { get; set; }
        public string FormaPago { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
        public string SerieReferencia { get; set; }
        public string NumeroReferencia { get; set; }
        public int? CodigoDocumentoReferencia { get; set; }
        public decimal? MontoIsc { get; set; }
        public decimal? MontoIgv { get; set; }
        public decimal? DescuentoGlobal { get; set; }
        public decimal? MontoAfecto { get; set; }
        public decimal? MontoInafecto { get; set; }
        public decimal? MontoExonerado { get; set; }
        public decimal? MontoRegalo { get; set; }
        public decimal? MontoDonacion { get; set; }
        public decimal? MontoTotal { get; set; }
        public byte? TipoVenta { get; set; }
        public decimal? TotalDescuento { get; set; }
        public byte? TipoIgv { get; set; }
        public string SerieReferencia2 { get; set; }
        public string NumeroReferencia2 { get; set; }
        public int? CodigoDocumentoReferencia2 { get; set; }
        public byte? ClienteConsumidorFinal { get; set; }
        public byte? TipoAgenteTributario { get; set; }
        public decimal? ImportePercepcion { get; set; }
        public string OrdenCompra { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string EmailCliente { get; set; }
        public byte? TrasladoContabilidad { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }
        public string CodigoDetraccion { get; set; }
        public decimal? PorcentajeDetraccion { get; set; }
        public string GlosaDetraccion { get; set; }
        public bool FlagSunat { get; set; }
        public bool FlagFe { get; set; }
        public string CodigoSunat { get; set; }
        public string EnvioXml { get; set; }
        public string RespuestaXml { get; set; }
        public string ArchivoPdf { get; set; }
        public string Mensaje { get; set; }
        public string EstadoSunat { get; set; }
        public DateTime? FechaAtraque { get; set; }
        public DateTime? FechaDesatraque { get; set; }
        public bool? AfectoDetraccion { get; set; }
        public string TransaccionHelm { get; set; }
        public string CodigoEmpresa { get; set; }
        public string CodigoOperacion { get; set; }
        public string NumeroOc { get; set; }
        public DateTime? FechaEmisionDocOrigen { get; set; }
        public bool? TrasladoHelm { get; set; }
        public bool? TrasladoOfisis { get; set; }
    }
}
