using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPaq.Models.Paq
{
    [Table("DetalleFactura")]
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
       
        public string TipoProducto { get; set; }
        public float PesoProducto { get; set; }
        public decimal MontoEnvio { get; set; }
        public decimal Precio { get; set; }


        public virtual Factura Factura { get; set; }
    }
}
