using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Multiproducto.BE.Producto
{
    public class ProductoResponse
    {
        public bool Result { get; set; }
        public ProductoResult Data { get; set; }
        public string Mensaje { get; set; }
    }
}
