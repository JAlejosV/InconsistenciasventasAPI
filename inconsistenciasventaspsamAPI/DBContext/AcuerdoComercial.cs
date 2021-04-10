using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class AcuerdoComercial
    {
        public long IdAcuerdoComercial { get; set; }
        public long IdTipoAcuerdoComercial { get; set; }
        public long IdSitio { get; set; }
        public string NumeroDocumentoCliente { get; set; }
        public int NumeroRam { get; set; }
        public int NumeroPractico { get; set; }
        public decimal? MontoLancha { get; set; }
        public decimal? PorcentajeRam { get; set; }
        public decimal? PorcentajePractico { get; set; }
        public bool? EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }

        public virtual Sitio IdSitioNavigation { get; set; }
        public virtual TipoAcuerdoComercial IdTipoAcuerdoComercialNavigation { get; set; }
    }
}
