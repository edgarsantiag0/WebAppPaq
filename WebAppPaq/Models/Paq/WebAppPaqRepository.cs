using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPaq.Data;

namespace WebAppPaq.Models.Paq
{
    public class WebAppPaqRepository : IWebAppPaqRepository
    {
        private ApplicationDbContext _context;

        public WebAppPaqRepository(ApplicationDbContext context)
        {
            _context = context; 

        }

        public IEnumerable<Factura> GetAllFacturas()
        {
            return _context.Facturas.ToList();
        }
    }
}
