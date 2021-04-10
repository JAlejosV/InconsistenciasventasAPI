using System;
using System.Collections.Generic;

#nullable disable

namespace inconsistenciasventaspsamAPI.DBContext
{
    public partial class Numerador
    {
        public long IdNumerador { get; set; }
        public long Factura { get; set; }
        public long Boleta { get; set; }
        public long NotaCredito { get; set; }
        public long NotaDebito { get; set; }
        public long FacturaTalara { get; set; }
        public long BoletaTalara { get; set; }
        public long NotaCreditoTalara { get; set; }
        public long NotaDebitoTalara { get; set; }
        public long OrdenCompra { get; set; }
        public long OrdenCompraTalara { get; set; }
    }
}
