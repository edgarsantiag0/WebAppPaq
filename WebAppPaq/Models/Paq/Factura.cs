using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPaq.Models.Paq
{
    [Table("Factura")]
    public class Factura
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string CedulaCliente { get; set; }        
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("Sucursal1")]
        public int? Sucursal1Id { get; set; }
        [ForeignKey("Sucursal2")]
        public int? Sucursal2Id { get; set; }

        public decimal Total { get; set; }


        [InverseProperty("Factura1")]
        public virtual Sucursal Sucursal1 { get; set; }

   
        [InverseProperty("Factura2")]
        public virtual Sucursal Sucursal2 { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
