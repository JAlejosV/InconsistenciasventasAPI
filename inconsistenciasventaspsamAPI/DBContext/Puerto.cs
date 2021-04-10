using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class Puerto
    {
        public Puerto()
        {
            CentroBeneficioPracticoSedes = new HashSet<CentroBeneficioPracticoSede>();
            Documentos = new HashSet<Documento>();
            Sitios = new HashSet<Sitio>();
        }

        public long IdPuerto { get; set; }
        public string NombrePuerto { get; set; }
        public bool? EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }

        public virtual ICollection<CentroBeneficioPracticoSede> CentroBeneficioPracticoSedes { get; set; }
        public virtual ICollection<Documento> Documentos { get; set; }
        public virtual ICollection<Sitio> Sitios { get; set; }
    }
}
