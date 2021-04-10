using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class Feriado
    {
        public long IdFeriado { get; set; }
        public DateTime Fecha { get; set; }
        public bool? EstadoRegistro { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
    }
}
