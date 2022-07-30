using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Multiproducto.BE.Solicitud
{
    public class SolicitudResponse
    {
        public bool Result { get; set; }
        public string Mensaje { get; set; }
        public SolicitudResult Data { get; set; }
    }
}
