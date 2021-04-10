using System;
using inconsistenciasventaspsamAPI.Dto_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class InterfacesDBContext : DbContext
    {
        public InterfacesDBContext()
        {
        }

        public InterfacesDBContext(DbContextOptions<InterfacesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcuerdoComercial> AcuerdoComercials { get; set; }
        public virtual DbSet<CentroBeneficioPracticoSede> CentroBeneficioPracticoSedes { get; set; }
        public virtual DbSet<ClgFactura> ClgFacturas { get; set; }
        public virtual DbSet<ClgRegistroFactura> ClgRegistroFacturas { get; set; }
        public virtual DbSet<ClienteConcatenado> ClienteConcatenados { get; set; }
        public virtual DbSet<ClienteRelacionado> ClienteRelacionados { get; set; }
        public virtual DbSet<ClientesShortName> ClientesShortNames { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<CompraDetalle> CompraDetalles { get; set; }
        public virtual DbSet<CompraDocumentoRef> CompraDocumentoRefs { get; set; }
        public virtual DbSet<CorrelativoFacturacion> CorrelativoFacturacions { get; set; }
        public virtual DbSet<Documento> Documentos { get; set; }
        public virtual DbSet<DocumentoCompress> DocumentoCompresses { get; set; }
        public virtual DbSet<DocumentoDetalle> DocumentoDetalles { get; set; }
        public virtual DbSet<DocumentoDetalleIntegral> DocumentoDetalleIntegrals { get; set; }
        public virtual DbSet<DocumentoDetalleMasivo> DocumentoDetalleMasivos { get; set; }
        public virtual DbSet<DocumentoIntegral> DocumentoIntegrals { get; set; }
        public virtual DbSet<DocumentoMasivo> DocumentoMasivos { get; set; }
        public virtual DbSet<Feriado> Feriados { get; set; }
        public virtual DbSet<Jsontable> Jsontables { get; set; }
        public virtual DbSet<Jsontable2> Jsontable2s { get; set; }
        public virtual DbSet<LimiteCredito> LimiteCreditos { get; set; }
        public virtual DbSet<Numerador> Numeradors { get; set; }
        public virtual DbSet<Puerto> Puertos { get; set; }
        public virtual DbSet<Sitio> Sitios { get; set; }
        public virtual DbSet<SitioDetalle> SitioDetalles { get; set; }
        public virtual DbSet<TarifaDetraccion> TarifaDetraccions { get; set; }
        public virtual DbSet<TipoAcuerdoComercial> TipoAcuerdoComercials { get; set; }
        public virtual DbSet<TipoSitio> TipoSitios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=sqlqa.psamperu.com;initial catalog=InterfacesDB;user id=adminsql;password=Sistemas2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<HuecoFacturacionDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<VentaDiferenciaCantidadDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<VentaDiferenciaMontoDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<AcuerdoComercial>(entity =>
            {
                entity.HasKey(e => e.IdAcuerdoComercial)
                    .HasName("PK__AcuerdoC__2D840AC0BA10BD92");

                entity.ToTable("AcuerdoComercial");

                entity.HasIndex(e => new { e.IdAcuerdoComercial, e.IdTipoAcuerdoComercial, e.IdSitio, e.NumeroDocumentoCliente, e.EstadoRegistro }, "IDX_AcuerdoComercial01")
                    .HasFillFactor((byte)98);

                entity.HasIndex(e => new { e.IdTipoAcuerdoComercial, e.IdSitio, e.NumeroDocumentoCliente, e.NumeroRam, e.NumeroPractico, e.EstadoRegistro }, "IDX_AcuerdoComercial02")
                    .IsUnique()
                    .HasFillFactor((byte)98);

                entity.Property(e => e.EstadoRegistro)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MontoLancha).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.NumeroDocumentoCliente)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroRam).HasColumnName("NumeroRAM");

                entity.Property(e => e.PorcentajePractico).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.PorcentajeRam)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("PorcentajeRAM");

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");

                entity.HasOne(d => d.IdSitioNavigation)
                    .WithMany(p => p.AcuerdoComercials)
                    .HasForeignKey(d => d.IdSitio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcuerdoComercial_Sitio");

                entity.HasOne(d => d.IdTipoAcuerdoComercialNavigation)
                    .WithMany(p => p.AcuerdoComercials)
                    .HasForeignKey(d => d.IdTipoAcuerdoComercial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcuerdoComercial_TipoAcuerdoComercial");
            });

            modelBuilder.Entity<CentroBeneficioPracticoSede>(entity =>
            {
                entity.HasKey(e => e.IdCentroBeneficioPracticoSede)
                    .HasName("PK__CentroBe__C152CAE6B51AFB1C");

                entity.ToTable("CentroBeneficioPracticoSede");

                entity.Property(e => e.CentroBeneficio)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoRegistro)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");

                entity.HasOne(d => d.IdPuertoNavigation)
                    .WithMany(p => p.CentroBeneficioPracticoSedes)
                    .HasForeignKey(d => d.IdPuerto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CentroBeneficioPracticoSede_Puerto");
            });

            modelBuilder.Entity<ClgFactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLG_Facturas");

                entity.Property(e => e.Concatenado)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoPagado)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Moneda)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MontoDeuda).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MontoPagado).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MontoTotal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSolidario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumentoCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumentoSolidario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Serie)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ShortNameCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortNameLc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ShortNameLC");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClgRegistroFactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLG_RegistroFacturas");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("moneda");

                entity.Property(e => e.MontoPagado).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MontoPendiente).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MontoTotal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Serie)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("serie");

                entity.Property(e => e.VtrmvcCodapl)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("vtrmvc_codapl");

                entity.Property(e => e.VtrmvcCodfor)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("vtrmvc_codfor");

                entity.Property(e => e.VtrmvcNroapl).HasColumnName("vtrmvc_nroapl");

                entity.Property(e => e.VtrmvcNrofor).HasColumnName("vtrmvc_nrofor");
            });

            modelBuilder.Entity<ClienteConcatenado>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClienteConcatenado");

                entity.Property(e => e.Concatenado)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSolidario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumentoCliente)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShortNameCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortNameLc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ShortNameLC");
            });

            modelBuilder.Entity<ClienteRelacionado>(entity =>
            {
                entity.HasKey(e => e.IdClienteRelacionado)
                    .HasName("PK__ClienteR__6B986BD5C306A249");

                entity.ToTable("ClienteRelacionado");

                entity.HasIndex(e => new { e.IdClienteRelacionado, e.NumeroDocumento, e.NombreCliente, e.EstadoRegistro }, "IDX_ClienteRelacionado01")
                    .HasFillFactor((byte)98);

                entity.Property(e => e.EstadoRegistro)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");
            });

            modelBuilder.Entity<ClientesShortName>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClientesShortName");

                entity.Property(e => e.NombreCliente).HasMaxLength(100);

                entity.Property(e => e.NumeroDocumentoCliente).HasMaxLength(20);

                entity.Property(e => e.ShortNameCliente).HasMaxLength(100);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra);

                entity.ToTable("Compra");

                entity.HasIndex(e => new { e.NumSerie, e.NumDocumento, e.DocumentoProveedor }, "Compras_Unicas")
                    .IsUnique();

                entity.Property(e => e.IdCompra).ValueGeneratedNever();

                entity.Property(e => e.CodigoDetraccion)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoOperacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DescuentoGlobal).HasColumnType("money");

                entity.Property(e => e.Detraccion).HasColumnType("money");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentoProveedor)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoSunat)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaAprobacion).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaEmision).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.FormaPago)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Igv)
                    .HasColumnType("money")
                    .HasColumnName("IGV");

                entity.Property(e => e.ImportePercepcion)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ImporteSubTotal).HasColumnType("money");

                entity.Property(e => e.ImporteTotal).HasColumnType("money");

                entity.Property(e => e.ImporteTotalTexto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Isc)
                    .HasColumnType("money")
                    .HasColumnName("ISC");

                entity.Property(e => e.MotivoNota)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumSerie)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OrdenCompra)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PorcDescGlobal).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Proveedor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoMoneda)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotalDescuento).HasColumnType("money");

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioAprobador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorAfecto).HasColumnType("money");

                entity.Property(e => e.ValorDonacion)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ValorExonerado).HasColumnType("money");

                entity.Property(e => e.ValorInafecto).HasColumnType("money");

                entity.Property(e => e.ValorRegalo).HasColumnType("money");
            });

            modelBuilder.Entity<CompraDetalle>(entity =>
            {
                entity.HasKey(e => new { e.IdCompra, e.Correlativo })
                    .HasName("PK_DetalleCompra");

                entity.ToTable("CompraDetalle");

                entity.Property(e => e.Articulo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.CodigoSunat)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento).HasColumnType("money");

                entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");

                entity.Property(e => e.Igv)
                    .HasColumnType("money")
                    .HasColumnName("IGV");

                entity.Property(e => e.Isc)
                    .HasColumnType("money")
                    .HasColumnName("ISC");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PorcDescuento).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.PrecioUnitario).HasColumnType("money");

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.Unidad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorVentaBruto).HasColumnType("money");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.CompraDetalles)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompraDetalle_Compra");
            });

            modelBuilder.Entity<CompraDocumentoRef>(entity =>
            {
                entity.HasKey(e => new { e.IdCompra, e.Correlativo })
                    .HasName("PK__CompraDocumentoRef__FE");

                entity.ToTable("CompraDocumentoRef");

                entity.Property(e => e.ArchivoAdjunto)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");

                entity.Property(e => e.NumSerieDoc)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.CompraDocumentoRefs)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CompraDocumentoRef__IdCompra__");
            });

            modelBuilder.Entity<CorrelativoFacturacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CorrelativoFacturacion");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NombreTipoDocumento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Serie)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdCodigoDocumento)
                    .HasName("PK__Document__F82E7638FFDC569B");

                entity.ToTable("Documento");

                entity.Property(e => e.AfectoDetraccion).HasDefaultValueSql("((0))");

                entity.Property(e => e.ArchivoPdf)
                    .IsUnicode(false)
                    .HasColumnName("ArchivoPDF");

                entity.Property(e => e.ClienteConsumidorFinal).HasDefaultValueSql("((1))");

                entity.Property(e => e.CodigoDetraccion)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSunat)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSunatNcNd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CodigoSunatNC_ND");

                entity.Property(e => e.DescuentoGlobal)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('..')");

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EnviadoAnuladoOfisis).HasDefaultValueSql("((0))");

                entity.Property(e => e.EnvioXml)
                    .IsUnicode(false)
                    .HasColumnName("EnvioXML");

                entity.Property(e => e.Eslora).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EstadoSunat)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAtraque).HasColumnType("datetime");

                entity.Property(e => e.FechaDesatraque).HasColumnType("datetime");

                entity.Property(e => e.FechaEmision).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.FlagFe).HasColumnName("FlagFE");

                entity.Property(e => e.FormaPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Glosa)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GlosaDetraccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdHelm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImportePercepcion)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MontoAfecto)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoDonacion)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoExonerado)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoIgv)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("MontoIGV")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoInafecto)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoIsc)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("MontoISC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoRegalo)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoTotal)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreMotivoNcNd)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NombreMotivoNC_ND");

                entity.Property(e => e.NombreNave)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreNave2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSolidario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumentoCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumentoSolidario)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroReferencia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroReferencia2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OrdenCompra)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeDetraccion).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.RespuestaXml)
                    .IsUnicode(false)
                    .HasColumnName("RespuestaXML");

                entity.Property(e => e.Serie)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SerieReferencia)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SerieReferencia2)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TipoAgenteTributario).HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoCambio).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.TipoIgv)
                    .HasColumnName("TipoIGV")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.TotalDescuento)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TransaccionHelm)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Trb)
                    .HasColumnType("numeric(15, 3)")
                    .HasColumnName("TRB");

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPuertoNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.IdPuerto)
                    .HasConstraintName("FK__Documento__IdPue__39788055");
            });

            modelBuilder.Entity<DocumentoCompress>(entity =>
            {
                entity.HasKey(e => e.IdCodigoDocumento)
                    .HasName("PK__document__F82E7638B7978029");

                entity.ToTable("documento_compress");

                entity.Property(e => e.ArchivoPdf)
                    .IsUnicode(false)
                    .HasColumnName("ArchivoPDF");

                entity.Property(e => e.CodigoDetraccion)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSunat)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSunatNcNd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CodigoSunatNC_ND");

                entity.Property(e => e.DescuentoGlobal).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EnvioXml)
                    .IsUnicode(false)
                    .HasColumnName("EnvioXML");

                entity.Property(e => e.Eslora).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.EstadoSunat)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEmision).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.FlagFe).HasColumnName("FlagFE");

                entity.Property(e => e.FormaPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Glosa)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GlosaDetraccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdHelm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImportePercepcion).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MontoAfecto).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.MontoDonacion).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.MontoExonerado).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.MontoIgv)
                    .HasColumnType("numeric(15, 3)")
                    .HasColumnName("MontoIGV");

                entity.Property(e => e.MontoInafecto).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.MontoIsc)
                    .HasColumnType("numeric(15, 3)")
                    .HasColumnName("MontoISC");

                entity.Property(e => e.MontoRegalo).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.MontoTotal).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreMotivoNcNd)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NombreMotivoNC_ND");

                entity.Property(e => e.NombreNave)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSolidario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumentoCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroReferencia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroReferencia2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OrdenCompra)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeDetraccion).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.RespuestaXml)
                    .IsUnicode(false)
                    .HasColumnName("RespuestaXML");

                entity.Property(e => e.Serie)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SerieReferencia)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SerieReferencia2)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCambio).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.TipoIgv).HasColumnName("TipoIGV");

                entity.Property(e => e.TotalDescuento).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.Trb)
                    .HasColumnType("numeric(15, 3)")
                    .HasColumnName("TRB");

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DocumentoDetalle>(entity =>
            {
                entity.HasKey(e => e.IdCodigoDocumentoDetalle)
                    .HasName("PK__Document__19A073689F995D0E");

                entity.ToTable("DocumentoDetalle");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CodigoArticulo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoConcepto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaContableProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EsDescuento).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdHelm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImportePercepcion)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoBruto)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoIgv)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("MontoIGV")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoIsc)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("MontoISC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MontoMinimoConsumidorFinal)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NombreArticulo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUnidadMedida)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajePercepcionArticulo)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PorcentajePercepcionVenta)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("numeric(15, 5)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SiglaUnidadMedida)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TasaIsc)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("TasaISC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoConcepto)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIsc)
                    .HasColumnName("TipoISC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoPercepcion).HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadMedidaSunat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ZZ')");

                entity.HasOne(d => d.IdCodigoDocumentoNavigation)
                    .WithMany(p => p.DocumentoDetalles)
                    .HasForeignKey(d => d.IdCodigoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoDetalle_Documento");
            });

            modelBuilder.Entity<DocumentoDetalleIntegral>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoDetalleIntegral)
                    .HasName("PK__Document__9DCE44FF765813E9");

                entity.ToTable("DocumentoDetalleIntegral");

                entity.HasIndex(e => new { e.IdDocumentoDetalleIntegral, e.IdCodigoDocumentoDetalle, e.ItemDetalle, e.ItemIntegral, e.CodigoProducto, e.CentroBeneficio, e.TipoRecurso, e.FechaHoraCreacion }, "IDX_DocumentoDetalleIntegral01")
                    .HasFillFactor((byte)98);

                entity.HasIndex(e => new { e.IdCodigoDocumentoDetalle, e.ItemDetalle, e.ItemIntegral }, "IDX_DocumentoDetalleIntegral02")
                    .IsUnique()
                    .HasFillFactor((byte)98);

                entity.Property(e => e.AfectoIgv).HasColumnName("AfectoIGV");

                entity.Property(e => e.Cantidad).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.CentroBeneficio)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PorcentajeDescuento)
                    .HasColumnType("numeric(15, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioUnitario).HasColumnType("numeric(15, 5)");

                entity.Property(e => e.TipoRecurso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdCodigoDocumentoDetalleNavigation)
                    .WithMany(p => p.DocumentoDetalleIntegrals)
                    .HasForeignKey(d => d.IdCodigoDocumentoDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoDetalleIntegral_Documento");
            });

            modelBuilder.Entity<DocumentoDetalleMasivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DocumentoDetalleMasivo");

                entity.Property(e => e.Cantidad).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.CodigoArticulo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoConcepto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaContableProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.IdCodigoDocumentoDetalle).ValueGeneratedOnAdd();

                entity.Property(e => e.IdHelm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImportePercepcion).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.MontoBruto).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.MontoIgv)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("MontoIGV");

                entity.Property(e => e.MontoIsc)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("MontoISC");

                entity.Property(e => e.MontoMinimoConsumidorFinal).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.NombreArticulo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUnidadMedida)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeDescuento).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.PorcentajePercepcionArticulo).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.PorcentajePercepcionVenta).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.PrecioUnitario).HasColumnType("numeric(15, 5)");

                entity.Property(e => e.SiglaUnidadMedida)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.TasaIsc)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("TasaISC");

                entity.Property(e => e.TipoConcepto)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIsc).HasColumnName("TipoISC");

                entity.Property(e => e.TipoProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadMedidaSunat)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DocumentoIntegral>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoIntegral)
                    .HasName("PK__Document__E3E99612286979F9");

                entity.ToTable("DocumentoIntegral");

                entity.HasIndex(e => new { e.IdDocumentoIntegral, e.IdCodigoDocumento, e.IdHelm, e.CodigoSitioFromLocation, e.CodigoSitioToLocation, e.NumeroRam, e.NumeroPractico, e.FechaHoraCreacion }, "IDX_DocumentoIntegral01")
                    .HasFillFactor((byte)98);

                entity.HasIndex(e => new { e.IdCodigoDocumento, e.IdHelm }, "IDX_DocumentoIntegral02")
                    .IsUnique()
                    .HasFillFactor((byte)98);

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdHelm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreServicio)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroRam).HasColumnName("NumeroRAM");

                entity.HasOne(d => d.IdCodigoDocumentoNavigation)
                    .WithMany(p => p.DocumentoIntegrals)
                    .HasForeignKey(d => d.IdCodigoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentoIntegral_Documento");
            });

            modelBuilder.Entity<DocumentoMasivo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DocumentoMasivo");

                entity.Property(e => e.ArchivoPdf)
                    .IsUnicode(false)
                    .HasColumnName("ArchivoPDF");

                entity.Property(e => e.CodigoDetraccion)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoEmpresa)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoOperacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSunat)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSunatNcNd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CodigoSunatNC_ND");

                entity.Property(e => e.DescuentoGlobal).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EnvioXml)
                    .IsUnicode(false)
                    .HasColumnName("EnvioXML");

                entity.Property(e => e.Eslora).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.EstadoSunat)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAtraque).HasColumnType("datetime");

                entity.Property(e => e.FechaDesatraque).HasColumnType("datetime");

                entity.Property(e => e.FechaEmision).HasColumnType("datetime");

                entity.Property(e => e.FechaEmisionDocOrigen).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.FlagFe).HasColumnName("FlagFE");

                entity.Property(e => e.FormaPago)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Glosa)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GlosaDetraccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdCodigoDocumento).ValueGeneratedOnAdd();

                entity.Property(e => e.IdHelm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImportePercepcion).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MontoAfecto).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.MontoDonacion).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.MontoExonerado).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.MontoIgv)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("MontoIGV");

                entity.Property(e => e.MontoInafecto).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.MontoIsc)
                    .HasColumnType("numeric(15, 2)")
                    .HasColumnName("MontoISC");

                entity.Property(e => e.MontoRegalo).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.MontoTotal).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreMotivoNcNd)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NombreMotivoNC_ND");

                entity.Property(e => e.NombreNave)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSolidario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumentoCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroOc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NumeroOC");

                entity.Property(e => e.NumeroReferencia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroReferencia2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OrdenCompra)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeDetraccion).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.RespuestaXml)
                    .IsUnicode(false)
                    .HasColumnName("RespuestaXML");

                entity.Property(e => e.Serie)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SerieReferencia)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SerieReferencia2)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCambio).HasColumnType("numeric(15, 3)");

                entity.Property(e => e.TipoIgv).HasColumnName("TipoIGV");

                entity.Property(e => e.TotalDescuento).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.TransaccionHelm)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Trb)
                    .HasColumnType("numeric(15, 3)")
                    .HasColumnName("TRB");

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Feriado>(entity =>
            {
                entity.HasKey(e => e.IdFeriado)
                    .HasName("PK__Feriado__8A3082C499021464");

                entity.ToTable("Feriado");

                entity.HasIndex(e => new { e.IdFeriado, e.Fecha, e.EstadoRegistro, e.FechaHoraCreacion }, "IDX_Feriado01")
                    .HasFillFactor((byte)98);

                entity.HasIndex(e => new { e.Fecha, e.EstadoRegistro }, "IDX_Feriado02")
                    .IsUnique()
                    .HasFillFactor((byte)98);

                entity.Property(e => e.EstadoRegistro)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");
            });

            modelBuilder.Entity<Jsontable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("jsontable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Txt).HasColumnName("txt");
            });

            modelBuilder.Entity<Jsontable2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("jsontable2");

                entity.Property(e => e.AccountNumber).HasMaxLength(100);

                entity.Property(e => e.AccountsName).HasMaxLength(200);

                entity.Property(e => e.Ccidf)
                    .HasMaxLength(100)
                    .HasColumnName("CCIDF");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.IsActive).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.NombreCliente).HasMaxLength(200);

                entity.Property(e => e.NumeroDocumentoCliente).HasMaxLength(100);

                entity.Property(e => e.ShortName).HasMaxLength(150);

                entity.Property(e => e.ShortNameCliente).HasMaxLength(100);
            });

            modelBuilder.Entity<LimiteCredito>(entity =>
            {
                entity.HasKey(e => e.ShortNameLc);

                entity.ToTable("LimiteCredito");

                entity.Property(e => e.ShortNameLc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ShortNameLC");

                entity.Property(e => e.MonedaCredito)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MontoLimiteCredito).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<Numerador>(entity =>
            {
                entity.HasKey(e => e.IdNumerador);

                entity.ToTable("Numerador");

                entity.Property(e => e.BoletaTalara).HasDefaultValueSql("((1))");

                entity.Property(e => e.FacturaTalara).HasDefaultValueSql("((1))");

                entity.Property(e => e.NotaCreditoTalara).HasDefaultValueSql("((1))");

                entity.Property(e => e.NotaDebitoTalara).HasDefaultValueSql("((1))");

                entity.Property(e => e.OrdenCompra).HasDefaultValueSql("((1))");

                entity.Property(e => e.OrdenCompraTalara).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Puerto>(entity =>
            {
                entity.HasKey(e => e.IdPuerto)
                    .HasName("PK__Puerto__4A275A55DF5F8227");

                entity.ToTable("Puerto");

                entity.HasIndex(e => new { e.IdPuerto, e.NombrePuerto, e.EstadoRegistro }, "IDX_Puerto01")
                    .HasFillFactor((byte)98);

                entity.Property(e => e.EstadoRegistro)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombrePuerto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");
            });

            modelBuilder.Entity<Sitio>(entity =>
            {
                entity.HasKey(e => e.IdSitio)
                    .HasName("PK__Sitio__B10A76ED1F4A2E99");

                entity.ToTable("Sitio");

                entity.HasIndex(e => new { e.IdSitio, e.IdPuerto, e.CodigoSitio, e.EstadoRegistro }, "IDX_Sitio01")
                    .HasFillFactor((byte)98);

                entity.HasIndex(e => new { e.IdPuerto, e.CodigoSitio, e.EstadoRegistro }, "IDX_Sitio02")
                    .IsUnique()
                    .HasFillFactor((byte)98);

                entity.Property(e => e.EstadoRegistro)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");

                entity.HasOne(d => d.IdPuertoNavigation)
                    .WithMany(p => p.Sitios)
                    .HasForeignKey(d => d.IdPuerto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sitio_Puerto");
            });

            modelBuilder.Entity<SitioDetalle>(entity =>
            {
                entity.HasKey(e => e.IdSitioDetalle)
                    .HasName("PK__SitioDet__27635D2759564ADE");

                entity.ToTable("SitioDetalle");

                entity.HasIndex(e => new { e.IdSitioDetalle, e.IdSitio, e.IdTipoSitio, e.NombreSitio, e.NombreSitioPadre, e.EstadoRegistro }, "IDX_SitioDetalle01")
                    .HasFillFactor((byte)98);

                entity.Property(e => e.EstadoRegistro)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreSitio)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSitioPadre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");

                entity.HasOne(d => d.IdSitioNavigation)
                    .WithMany(p => p.SitioDetalles)
                    .HasForeignKey(d => d.IdSitio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SitioDetalle_Sitio");

                entity.HasOne(d => d.IdTipoSitioNavigation)
                    .WithMany(p => p.SitioDetalles)
                    .HasForeignKey(d => d.IdTipoSitio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SitioDetalle_TipoSitio");
            });

            modelBuilder.Entity<TarifaDetraccion>(entity =>
            {
                entity.ToTable("TarifaDetraccion");

                entity.HasIndex(e => e.NombreArticulo, "IDX_NombreArticulo")
                    .HasFillFactor((byte)98);

                entity.Property(e => e.CentroBeneficio)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoDetraccion)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NombreArticulo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TopeMinimoDolares).HasColumnType("numeric(15, 2)");

                entity.Property(e => e.TopeMinimoSoles).HasColumnType("numeric(15, 2)");
            });

            modelBuilder.Entity<TipoAcuerdoComercial>(entity =>
            {
                entity.HasKey(e => e.IdTipoAcuerdoComercial)
                    .HasName("PK__TipoAcue__1089CF0A999A6C67");

                entity.ToTable("TipoAcuerdoComercial");

                entity.HasIndex(e => new { e.IdTipoAcuerdoComercial, e.NombreTipoAcuerdoComercial, e.EstadoRegistro }, "IDX_TipoAcuerdoComercial01")
                    .HasFillFactor((byte)98);

                entity.Property(e => e.EstadoRegistro)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreTipoAcuerdoComercial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");
            });

            modelBuilder.Entity<TipoSitio>(entity =>
            {
                entity.HasKey(e => e.IdTipoSitio)
                    .HasName("PK__TipoSiti__4FDB63B628B662F0");

                entity.ToTable("TipoSitio");

                entity.HasIndex(e => new { e.IdTipoSitio, e.NombreSitio, e.EstadoRegistro }, "IDX_TipoSitio01")
                    .HasFillFactor((byte)98);

                entity.Property(e => e.EstadoRegistro)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaHoraActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreSitio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioActualizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(user_name())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
