using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPaq.Models.Paq;

namespace WebAppPaq.Data
{
    public class WebAppPaqSeedData
    {

        private ApplicationDbContext _context;

        public WebAppPaqSeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Facturas.Any())
            {
                var facturaNueva = new Factura()
                {
                    NombreCliente = "Jhon",
                    ApellidoCliente = "Diaz",
                    CedulaCliente = "001-9981768-8",
                    FechaCreacion = DateTime.UtcNow,
                    TelefonoCliente = "809-567-9090",
                    Total = 1590,
                    Sucursal1 = new Sucursal()
                    {
                        Ciudad = "La Vega",
                        Descripcion = "Sucursal de ventas",
                        Direccion = "Calle 10, Gurabo",
                    },
                    Sucursal2 = new Sucursal()
                    {
                        Ciudad = "San Fco de Macoris",
                        Descripcion = "Sucursal principal",
                        Direccion = "Lopez de vega",
                    },
                    Usuario = "",
                    DetalleFacturas = new List<DetalleFactura>()
                    {
                        new DetalleFactura(){ MontoEnvio = 1200, Precio = 200, TipoProducto = "Dinero"},
                        new DetalleFactura(){ MontoEnvio = 500, Precio = 200, TipoProducto = "Dinero"},
                        new DetalleFactura(){ MontoEnvio = 200, Precio = 200, TipoProducto = "Dinero"},
                        new DetalleFactura(){ MontoEnvio = 900, Precio = 200, TipoProducto = "Dinero"},
                        new DetalleFactura(){ MontoEnvio = 2340, Precio = 200, TipoProducto = "Dinero"},
                        new DetalleFactura(){ MontoEnvio = 4320, Precio = 200, TipoProducto = "Dinero"}


                    }

                };

                _context.Facturas.Add(facturaNueva);

                _context.DetalleFacturas.AddRange(facturaNueva.DetalleFacturas);

                var facturaNueva2 = new Factura()
                {
                    NombreCliente = "Albert",
                    ApellidoCliente = "Diaz",
                    CedulaCliente = "001-9981768-8",
                    FechaCreacion = DateTime.UtcNow,
                    TelefonoCliente = "809-567-9090",
                    Total = 1590,
                    Sucursal1 = new Sucursal()
                    {
                        Ciudad = "Santiago",
                        Descripcion = "Sucursal de ventas",
                        Direccion = "Calle 10, Gurabo",
                    },
                    Sucursal2 = new Sucursal()
                    {
                        Ciudad = "Santo Domingo",
                        Descripcion = "Sucursal principal",
                        Direccion = "Lopez de vega",
                    },
                    Usuario = "",
                    DetalleFacturas = new List<DetalleFactura>()
                    {
                         new DetalleFactura(){ MontoEnvio = 1200, Precio = 200, TipoProducto = "Dinero"},
                        new DetalleFactura(){ MontoEnvio = 500, Precio = 200, TipoProducto = "Dinero"},
                        new DetalleFactura(){ MontoEnvio = 200, Precio = 200, TipoProducto = "Dinero"},
                        new DetalleFactura(){ MontoEnvio = 900, Precio = 200, TipoProducto = "Dinero"},
                        new DetalleFactura(){ MontoEnvio = 2340, Precio = 200, TipoProducto = "Dinero"},
                        new DetalleFactura(){ MontoEnvio = 4320, Precio = 200, TipoProducto = "Dinero"}

                    }

                };

                _context.Facturas.Add(facturaNueva2);

                _context.DetalleFacturas.AddRange(facturaNueva2.DetalleFacturas);

                await _context.SaveChangesAsync();

            }


        }
    }
}
