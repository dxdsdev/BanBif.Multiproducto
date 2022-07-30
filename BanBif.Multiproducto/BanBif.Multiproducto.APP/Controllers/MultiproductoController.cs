using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BanBif.Multiproducto.BE.Cliente;
using BanBif.Multiproducto.BE.Log;
using BanBif.Multiproducto.BE.Producto;
using BanBif.Multiproducto.BE.Token;
using BanBif.Multiproducto.BE.Correo;
using BanBif.Multiproducto.BE.Solicitud;
using BanBif.Multiproducto.APP.Util;

using Newtonsoft.Json;
using System.Web.Http;

namespace BanBif.Multiproducto.APP.Controllers
{
    public class MultiproductoController : Controller
    {
        // GET: Multiproducto
        public ActionResult Index()
        {
            ViewBag.App = ConfigurationManager.AppSettings.Get("UrlAPP").ToString();
            ViewBag.URL = ConfigurationManager.AppSettings.Get("UrlAPP").ToString();
            return View();
        }


        public ActionResult Productos()
        {
            ViewBag.App = ConfigurationManager.AppSettings.Get("UrlAPP").ToString();
            ViewBag.URL = ConfigurationManager.AppSettings.Get("UrlAPP").ToString();
            return View();
        }

        //[Route("Multiproducto/ObtenerCliente")]
        //[HttpPost]
        public ActionResult ObtenerCliente(ClienteRequest request)
        {

            ClienteResponse contenidoResponse = new ClienteResponse();

            try
            {
                ClienteResult oListarRazaResult = new ClienteResult();
                string strURL = ConfigurationManager.AppSettings["UrlAPI"] + "api/multiproducto/ObtenerCliente";
                string response = WebApi<ClienteRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ClienteResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }
            
            return Json(contenidoResponse);

        }


        //[Route("Multiproducto/ObtenerProductos/")]
        //[HttpPost]

        [System.Web.Http.Route("Multiproducto/ObtenerProductos/")]
        [System.Web.Http.HttpPost]
        public ActionResult ObtenerProductos(ProductoRequest request)
        {

            ProductoResponse contenidoResponse = new ProductoResponse();

            try
            {
                ProductoRequest oListarRazaResult = new ProductoRequest();
                string strURL = ConfigurationManager.AppSettings["UrlAPI"] + "api/multiproducto/ObtenerProductos";
                string response = WebApi<ProductoRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ProductoResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }
            
            return Json(contenidoResponse);

        }


        [System.Web.Http.Route("Multiproducto/ObtenerProductosSegmento/")]
        [System.Web.Http.HttpPost]
        public ActionResult ObtenerProductosSegmento(ProductoRequest request)
        {

            ProductoResponse contenidoResponse = new ProductoResponse();

            try
            {
                ProductoRequest oListarRazaResult = new ProductoRequest();
                string strURL = ConfigurationManager.AppSettings["UrlAPI"] + "api/multiproducto/ObtenerProductosSegmento";
                string response = WebApi<ProductoRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<ProductoResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }

            return Json(contenidoResponse);

        }


        [System.Web.Http.Route("Multiproducto/RegistrarLog/")]
        [System.Web.Http.HttpPost]
        public ActionResult RegistrarLog(LogRequest request)
        {

            LogResponse contenidoResponse = new LogResponse();

            try
            {
                LogRequest oListarRazaResult = new LogRequest();
                string strURL = ConfigurationManager.AppSettings["UrlAPI"] + "api/multiproducto/RegistrarLog";
                string response = WebApi<LogRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<LogResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }

            return Json(contenidoResponse);

        }



        [System.Web.Http.Route("Multiproducto/RegistrarSolicitud/")]
        [System.Web.Http.HttpPost]
        public ActionResult RegistrarSolicitud(SolicitudRequest request)
        {

            SolicitudResponse contenidoResponse = new SolicitudResponse();

            try
            {
                SolicitudRequest oListarRazaResult = new SolicitudRequest();
                string strURL = ConfigurationManager.AppSettings["UrlAPI"] + "api/multiproducto/RegistrarSolicitud";
                string response = WebApi<SolicitudRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<SolicitudResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
            }

            return Json(contenidoResponse);

        }

        [System.Web.Http.Route("Multiproducto/EnviarToken/")]
        [System.Web.Http.HttpPost]
        public ActionResult EnviarToken(EnviarRequest request)
        {
            CorreoResponse contenidoResponse = new CorreoResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["UrlAPI"] + "api/multiproducto/EnviarToken";
                string response = WebApi<EnviarRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<CorreoResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Enviado = false;
                contenidoResponse.Resultado = ex.InnerException.ToString();

            }
            return Json(contenidoResponse);
        }

        [System.Web.Http.Route("Multiproducto/ValidarToken/")]
        [System.Web.Http.HttpPost]
        public ActionResult ValidarToken(TokenRequest request)
        {
            TokenResponse contenidoResponse = new TokenResponse();

            try
            {
                string strURL = ConfigurationManager.AppSettings["UrlAPI"] + "api/multiproducto/ValidarToken";
                string response = WebApi<TokenRequest>.RequestWebApi(request, strURL);
                contenidoResponse = JsonConvert.DeserializeObject<TokenResponse>(response);
            }
            catch (Exception ex)
            {
                contenidoResponse.Result = false;
                contenidoResponse.Mensaje = ex.InnerException.ToString();

            }
            return Json(contenidoResponse);
        }






    }
}
