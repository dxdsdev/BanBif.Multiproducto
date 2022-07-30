using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanBif.Multiproducto.BE.Producto;

namespace BanBif.Multiproducto.DA
{
    public class Producto_AD
    {
        public ProductoResult ObtenerProductos()
        {
            using (panelEntities db = new panelEntities())
            {
                ProductoResult result = new ProductoResult();
                var lista = db.SP_MULTIPRODUCTO_OBTENER_PRODUCTOS().ToList();

                var listaResult = new List<ProductoObj>();
                foreach (var item in lista)
                {
                    listaResult.Add(new ProductoObj
                    {
                        productoid = item.productoid,
                        descripcion = item.descripcion,
                        detalle1 = item.detalle1,
                        detalle2 = item.detalle2,
                        condicion = item.condicion,
                        masinf = item.masinf,
                        segmento = item.segmento,
                        vigencia = item.vigencia,
                        fecreg = item.fecreg

                    });
                }
                result.Data = listaResult;
                return result;
            }

        }


        public ProductoResult ObtenerProductosSegmento(ProductoRequest request)
        {
            using (panelEntities db = new panelEntities())
            {
                ProductoResult result = new ProductoResult();
                var lista = db.SP_MULTIPRODUCTO_OBTENER_PRODUCTOS_SEGMENTO(request.segmento).ToList();

                var listaResult = new List<ProductoObj>();
                foreach (var item in lista)
                {
                    listaResult.Add(new ProductoObj
                    {
                        productoid = item.productoid,
                        descripcion = item.descripcion,
                        detalle1 = item.detalle1,
                        detalle2 = item.detalle2,
                        condicion = item.condicion,
                        masinf = item.masinf,
                        segmento = item.segmento,
                        vigencia = item.vigencia,
                        fecreg = item.fecreg

                    });
                }
                result.Data = listaResult;
                return result;
            }

        }

    }
}
