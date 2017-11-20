using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPaq.Models.Paq
{
    public class Factura
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string CedulaCliente { get; set; }        
        public DateTime FechaSolicitud { get; set; }

        public int SucursalId1 { get; set; }
        public int SucursalId2 { get; set; }
        public decimal Total { get; set; }


        public Sucursal Sucursal1 { get; set; }
        public Sucursal Sucursal2 { get; set; }
    }
}
