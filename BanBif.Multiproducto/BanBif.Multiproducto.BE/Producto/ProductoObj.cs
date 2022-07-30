using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Multiproducto.BE.Producto
{
    public class ProductoObj
    {
        public int productoid { get; set; }
        public string descripcion { get; set; }
        public string detalle1 { get; set; }
        public string detalle2 { get; set; }
        public string condicion { get; set; }
        public string masinf { get; set; }
        public Nullable<System.DateTime> vigencia { get; set; }
        public Nullable<int> segmento { get; set; }
        public Nullable<System.DateTime> fecreg { get; set; }
    }
}
