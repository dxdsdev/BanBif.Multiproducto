using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Multiproducto.BE.Cliente
{
    public class ClienteResponse
    {
        public bool Result { get; set; }
        public string Mensaje { get; set; }
        public ClienteResult Data { get; set; }
    }
}
