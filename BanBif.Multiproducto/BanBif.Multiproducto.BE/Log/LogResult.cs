using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Multiproducto.BE.Log
{
    public class LogResult
    {

        public int idregistro { get; set; }
        public string dni { get; set; }
        public Nullable<int> accion { get; set; }
        public string detalle { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }

    }
}
