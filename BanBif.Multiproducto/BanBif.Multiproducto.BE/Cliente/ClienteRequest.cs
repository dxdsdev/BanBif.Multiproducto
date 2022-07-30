using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Multiproducto.BE.Cliente
{
    public class ClienteRequest
    {
        public int clienteid { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string mail { get; set; }
        public string segmento { get; set; }
        public string celular { get; set; }
        public Nullable<System.DateTime> fecreg { get; set; }
        public Nullable<int> estado { get; set; }
    }
}
