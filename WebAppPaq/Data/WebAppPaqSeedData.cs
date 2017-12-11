using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPaq.Models;
using WebAppPaq.Models.Paq;

namespace WebAppPaq.Data
{
    public class WebAppPaqSeedData
    {

        private ApplicationDbContext _context;
    
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public WebAppPaqSeedData(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
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
                        Descripcion = "Sucursal de ventas, La Vega",
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
                                    Descripcion = "Sucursal principal, Santo Domingo",
                                    Direccion = "Calle 10, Gurabo",
                                }},
                        new DetalleFactura(){
                            MontoEnvio = 400,
                            Precio = 200, TipoProducto = "Dinero",
                            Sucursal = new Sucursal()
                                {
                                    Ciudad = "Pedernales",
                                    Descripcion = "Sucursal de ventas, Pedernales",
                                    Direccion = "Calle 10, Gurabo",
                                }}
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
                        Descripcion = "Sucursal de ventas, Puerto Plata",
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
                                    Descripcion = "Sucursal de ventas, Mao",
                                    Direccion = "Calle 10, Gurabo",
                                }},
                        new DetalleFactura(){
                            MontoEnvio = 400,
                            Precio = 200, TipoProducto = "Dinero",
                            Sucursal = new Sucursal()
                                {
                                    Ciudad = "Punta Cana",
                                    Descripcion = "Sucursal de ventas, Punta Cana",
                                    Direccion = "Calle 10, Gurabo",
                                }}
                    }
                };

                _context.Facturas.Add(facturaNueva2);

                _context.DetalleFacturas.AddRange(facturaNueva2.DetalleFacturas);

                await _context.SaveChangesAsync();

            }


        }
    }
}
