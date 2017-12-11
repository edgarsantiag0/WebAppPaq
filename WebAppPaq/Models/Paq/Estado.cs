using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPaq.Models.Paq
{
    public class Estado
    {
        public Estado()
        {
            this.Tracks = new HashSet<Track>();
        }

        public int EstadoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }

    }
}
