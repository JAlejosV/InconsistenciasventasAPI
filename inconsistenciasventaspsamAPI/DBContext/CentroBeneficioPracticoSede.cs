using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class CentroBeneficioPracticoSede
    {
        public long IdCentroBeneficioPracticoSede { get; set; }
        public long IdPuerto { get; set; }
        public string CentroBeneficio { get; set; }
        public bool? EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }

        public virtual Puerto IdPuertoNavigation { get; set; }
    }
}
