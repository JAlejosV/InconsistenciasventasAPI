using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class ClienteConcatenado
    {
        public string NumeroDocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ShortNameCliente { get; set; }
        public string NombreSolidario { get; set; }
        public string Concatenado { get; set; }
        public string ShortNameLc { get; set; }
    }
}
