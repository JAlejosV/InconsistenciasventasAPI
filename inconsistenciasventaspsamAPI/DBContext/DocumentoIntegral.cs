using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class DocumentoIntegral
    {
        public long IdDocumentoIntegral { get; set; }
        public long IdCodigoDocumento { get; set; }
        public string IdHelm { get; set; }
        public string NombreServicio { get; set; }
        public int? CodigoSitioFromLocation { get; set; }
        public int? CodigoSitioToLocation { get; set; }
        public int? NumeroRam { get; set; }
        public int? NumeroPractico { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }

        public virtual Documento IdCodigoDocumentoNavigation { get; set; }
    }
}
