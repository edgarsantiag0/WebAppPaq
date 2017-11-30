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

        public string NombreClienteEnvia { get; set; }
        public string ApellidoClienteEnvia { get; set; }
        public string TelefonoClienteEnvia { get; set; }
        public string CedulaClienteEnvia { get; set; }

        public string NombreClienteRecibe { get; set; }
        public string ApellidoClienteRecibe { get; set; }
        public string TelefonoClienteRecibe { get; set; }
        public string CedulaClienteRecibe { get; set; }

        private DateTime? fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return fechaCreacion ?? DateTime.Now; }
            set { fechaCreacion = value; }
        }

        public int? SucursalId { get; set; }

        public decimal Total { get; set; }

        public virtual Sucursal Sucursal { get; set; }

   


        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
