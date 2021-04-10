using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class Sitio
    {
        public Sitio()
        {
            AcuerdoComercials = new HashSet<AcuerdoComercial>();
            SitioDetalles = new HashSet<SitioDetalle>();
        }

        public long IdSitio { get; set; }
        public long IdPuerto { get; set; }
        public int? CodigoSitio { get; set; }
        public bool? EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }

        public virtual Puerto IdPuertoNavigation { get; set; }
        public virtual ICollection<AcuerdoComercial> AcuerdoComercials { get; set; }
        public virtual ICollection<SitioDetalle> SitioDetalles { get; set; }
    }
}
