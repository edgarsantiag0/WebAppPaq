using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPaq.Models.Paq
{
    [Table("Sucursal")]
    public class Sucursal
    {

        public Sucursal()
        {
            Factura = new HashSet<Factura>();
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }

 
        public virtual ICollection<Factura> Factura { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
