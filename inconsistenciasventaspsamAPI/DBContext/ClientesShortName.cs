using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class ClientesShortName
    {
        public string NumeroDocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ShortNameCliente { get; set; }
    }
}
