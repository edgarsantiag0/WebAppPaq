using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPaq.Models.Paq
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
        public string TipoProducto { get; set; }
        public float PesoProducto { get; set; }
        public decimal MontoEnvio { get; set; }
        public decimal PrecioFactura { get; set; }





    }
}
