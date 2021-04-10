using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class CompraDocumentoRef
    {
        public int IdCompra { get; set; }
        public short Correlativo { get; set; }
        public string TipoDocumento { get; set; }
        public string NumSerieDoc { get; set; }
        public string ArchivoAdjunto { get; set; }
        public bool EstaActivo { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
    }
}
