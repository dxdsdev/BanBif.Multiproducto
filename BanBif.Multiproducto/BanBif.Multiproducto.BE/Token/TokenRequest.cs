using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Multiproducto.BE.Token
{
    public class TokenRequest
    {
        public string Documento { get; set; }
        public int Token { get; set; }

        public int Estado { get; set; }
    }
}
