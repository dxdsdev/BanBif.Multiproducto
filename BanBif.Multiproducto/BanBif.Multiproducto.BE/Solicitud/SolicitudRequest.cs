using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Multiproducto.BE.Solicitud
{
    public class SolicitudRequest
    {

        public int registroid { get; set; }
        public Nullable<int> productoid { get; set; }
        public Nullable<int> clienteid { get; set; }
        public Nullable<System.DateTime> fecsol { get; set; }
        public string ipcliente { get; set; }
        public Nullable<int> estado { get; set; }

    }
}
