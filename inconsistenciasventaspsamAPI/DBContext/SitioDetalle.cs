using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class SitioDetalle
    {
        public long IdSitioDetalle { get; set; }
        public long IdSitio { get; set; }
        public long IdTipoSitio { get; set; }
        public string NombreSitio { get; set; }
        public string NombreSitioPadre { get; set; }
        public bool? EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }

        public virtual Sitio IdSitioNavigation { get; set; }
        public virtual TipoSitio IdTipoSitioNavigation { get; set; }
    }
}
