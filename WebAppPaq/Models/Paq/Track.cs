using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPaq.Models.Paq
{
    public class Track
    {
        public int TrackId { get; set; }

        public int DetalleFacturaId { get; set; }
        public int EstadoId { get; set; }


        public virtual DetalleFactura DetalleFactura { get; set; }

        public virtual Estado Estado { get; set; }



    }
}
