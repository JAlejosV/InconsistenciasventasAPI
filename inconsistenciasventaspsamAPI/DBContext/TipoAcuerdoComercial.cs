using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class TipoAcuerdoComercial
    {
        public TipoAcuerdoComercial()
        {
            AcuerdoComercials = new HashSet<AcuerdoComercial>();
        }

        public long IdTipoAcuerdoComercial { get; set; }
        public string NombreTipoAcuerdoComercial { get; set; }
        public bool? EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }

        public virtual ICollection<AcuerdoComercial> AcuerdoComercials { get; set; }
    }
}
