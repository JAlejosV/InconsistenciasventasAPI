﻿using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class TipoSitio
    {
        public TipoSitio()
        {
            SitioDetalles = new HashSet<SitioDetalle>();
        }

        public long IdTipoSitio { get; set; }
        public string NombreSitio { get; set; }
        public bool? EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime? FechaHoraActualizacion { get; set; }

        public virtual ICollection<SitioDetalle> SitioDetalles { get; set; }
    }
}
