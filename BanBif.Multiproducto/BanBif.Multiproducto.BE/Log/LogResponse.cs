using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Multiproducto.BE.Log
{
    public class LogResponse
    {

        public bool Result { get; set; }
        public string Mensaje { get; set; }
        public LogResult Data { get; set; }

    }
}
