using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.Web.Http;
using BanBif.Multiproducto.BL;
using BanBif.Multiproducto.BE.Cliente;
using BanBif.Multiproducto.BE.Log;
using BanBif.Multiproducto.BE.Producto;
using BanBif.Multiproducto.BE.Solicitud;
using BanBif.Multiproducto.BE.Correo;
using BanBif.Multiproducto.BE.Token;


namespace BanBif.Multiproducto.API.Controllers
{
    public class MultiProductoController : ApiController
    {
        [Route("api/multiproducto/ObtenerCliente")]
        [HttpPost]
        public IHttpActionResult ObtenerCliente(ClienteRequest request)
        {
            var oBL = new MultiproductoBL();
            var resultado = oBL.ConsultarCLiente(request);
            return Json(resultado);
        }


        [Route("api/multiproducto/ObtenerProductos")]
        [HttpPost]
        public IHttpActionResult ObtenerProductos()
        {
            var oBL = new MultiproductoBL();
            var resultado = oBL.ObtenerProductos();
            return Json(resultado);
        }

        [Route("api/multiproducto/ObtenerProductosSegmento")]
        [HttpPost]
        public IHttpActionResult ObtenerProductosSegmento(ProductoRequest request)
        {
            var oBL = new MultiproductoBL();
            var resultado = oBL.ObtenerProductosSegmento(request);
            return Json(resultado);
        }

        [Route("api/multiproducto/RegistrarLog")]
        [HttpPost]
        public IHttpActionResult RegistrarLog(LogResult request)
        {
            var oBL = new MultiproductoBL();
            var resultado = oBL.RegistrarLog(request);
            return Json(resultado);
        }

        [Route("api/multiproducto/RegistrarSolicitud")]
        [HttpPost]
        public IHttpActionResult RegistrarSolicitud(SolicitudResult request)
        {
            var oBL = new MultiproductoBL();
            var resultado = oBL.RegistrarSolicitud(request);
            return Json(resultado);
        }

        [Route("api/multiproducto/EnviarToken")]
        [HttpPost]
        public IHttpActionResult EnviarToken(EnviarRequest request)
        {
            var oBL = new MultiproductoBL();
            return Json(oBL.EnviarToken(request));
        }

        [Route("api/multiproducto/ValidarToken")]
        [HttpPost]
        public IHttpActionResult ValidarToken(TokenRequest request)
        {
            var oBL = new MultiproductoBL();
            return Json(oBL.ValidarToken(request));
        }

    }
}
