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
            Factura1 = new HashSet<Factura>();
            Factura2 = new HashSet<Factura>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }

        [InverseProperty("Sucursal1")]
        public virtual ICollection<Factura> Factura1 { get; set; }
       [InverseProperty("Sucursal2")]
        public virtual ICollection<Factura> Factura2 { get; set; }
    }
}
