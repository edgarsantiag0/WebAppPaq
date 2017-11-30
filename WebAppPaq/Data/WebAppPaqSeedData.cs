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
                    NombreClienteEnvia = "Jhon",
                    ApellidoClienteEnvia = "Diaz",
                    CedulaClienteEnvia = "001-9981768-8",
                    TelefonoClienteEnvia = "809-567-9090",

                    NombreClienteRecibe = "Jose",
                    ApellidoClienteRecibe = "Polanco",
                    CedulaClienteRecibe = "001-1231745-8",
                    TelefonoClienteRecibe = "809-543-0101",



                    FechaCreacion = DateTime.UtcNow,
                    
                    Total = 1590,
                    Sucursal = new Sucursal()
                    {
                        Ciudad = "La Vega",
                        Descripcion = "Sucursal de ventas",
                        Direccion = "Calle 10, Gurabo",
                    },
                  
                    Usuario = "",
                    DetalleFacturas = new List<DetalleFactura>()
                    {
                        new DetalleFactura(){
                            MontoEnvio = 1200,
                            Precio = 200, TipoProducto = "Dinero",
                            Sucursal = new Sucursal()
                                {
                                    Ciudad = "Santo Domingo",
                                    Descripcion = "Sucursal de ventas",
                                    Direccion = "Calle 10, Gurabo",
                                }},
                        new DetalleFactura(){
                            MontoEnvio = 400,
                            Precio = 200, TipoProducto = "Dinero",
                            Sucursal = new Sucursal()
                                {
                                    Ciudad = "Pedernales",
                                    Descripcion = "Sucursal de ventas",
                                    Direccion = "Calle 10, Gurabo",
                                }},
                        new DetalleFactura(){
                            MontoEnvio = 800,
                            Precio = 200, TipoProducto = "Dinero",
                            Sucursal = new Sucursal()
                                {
                                    Ciudad = "San Pedro de Macoris",
                                    Descripcion = "Sucursal de ventas",
                                    Direccion = "Calle 10, Gurabo",
                                }},
                        new DetalleFactura(){
                            MontoEnvio = 1200,
                            Precio = 200, TipoProducto = "Dinero",
                            Sucursal = new Sucursal()
                                {
                                    Ciudad = "Tenares",
                                    Descripcion = "Sucursal de ventas",
                                    Direccion = "Calle 10, Gurabo",
                                }},
                    }
                };

                _context.Facturas.Add(facturaNueva);

                _context.DetalleFacturas.AddRange(facturaNueva.DetalleFacturas);

                var facturaNueva2 = new Factura()
                {
                    NombreClienteEnvia = "Jhon",
                    ApellidoClienteEnvia = "Diaz",
                    CedulaClienteEnvia = "001-9981768-8",
                    TelefonoClienteEnvia = "809-567-9090",

                    NombreClienteRecibe = "Jose",
                    ApellidoClienteRecibe = "Polanco",
                    CedulaClienteRecibe = "001-1231745-8",
                    TelefonoClienteRecibe = "809-543-0101",



                    FechaCreacion = DateTime.UtcNow,

                    Total = 1590,
                    Sucursal = new Sucursal()
                    {
                        Ciudad = "Puerto Plata",
                        Descripcion = "Sucursal de ventas",
                        Direccion = "Calle 10, Gurabo",
                    },

                    Usuario = "",
                    DetalleFacturas = new List<DetalleFactura>()
                    {
                        new DetalleFactura(){
                            MontoEnvio = 1200,
                            Precio = 200, TipoProducto = "Dinero",
                            Sucursal = new Sucursal()
                                {
                                    Ciudad = "Mao",
                                    Descripcion = "Sucursal de ventas",
                                    Direccion = "Calle 10, Gurabo",
                                }},
                        new DetalleFactura(){
                            MontoEnvio = 400,
                            Precio = 200, TipoProducto = "Dinero",
                            Sucursal = new Sucursal()
                                {
                                    Ciudad = "Punta Cana",
                                    Descripcion = "Sucursal de ventas",
                                    Direccion = "Calle 10, Gurabo",
                                }},
                        new DetalleFactura(){
                            MontoEnvio = 800,
                            Precio = 200, TipoProducto = "Dinero",
                            Sucursal = new Sucursal()
                                {
                                    Ciudad = "San Francisco",
                                    Descripcion = "Sucursal de ventas",
                                    Direccion = "Calle 10, Gurabo",
                                }},
                        new DetalleFactura(){
                            MontoEnvio = 1200,
                            Precio = 200, TipoProducto = "Dinero",
                            Sucursal = new Sucursal()
                                {
                                    Ciudad = "Salcedo",
                                    Descripcion = "Sucursal de ventas",
                                    Direccion = "Calle 10, Gurabo",
                                }},
                    }
                };

                _context.Facturas.Add(facturaNueva2);

                _context.DetalleFacturas.AddRange(facturaNueva2.DetalleFacturas);

                await _context.SaveChangesAsync();

            }


        }
    }
}
