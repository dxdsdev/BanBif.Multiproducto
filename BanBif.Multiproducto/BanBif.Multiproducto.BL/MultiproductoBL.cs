﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanBif.Multiproducto.BE.Cliente;
using BanBif.Multiproducto.BE.Log;
using BanBif.Multiproducto.BE.Producto;
using BanBif.Multiproducto.BE.Solicitud;
using BanBif.Multiproducto.BE.Token;
using BanBif.Multiproducto.BE.Correo;
using BanBif.Multiproducto.DA;

namespace BanBif.Multiproducto.BL
{
    public  class MultiproductoBL
    {

        public ClienteResponse ConsultarCLiente(ClienteRequest request)
        {
            var response = new ClienteResponse();
            try
            {
                //var comisionesDA = new ComisionesxConsultaDA();
                var objAD = new Cliente_AD();

                var resultado = objAD.ConsultarCLiente(request);

                if (resultado!= null)
                {
                    response.Result = true;
                    response.Data = resultado;
                    response.Mensaje = "Consulta Correcta.";
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;

        }

        public ProductoResponse ObtenerProductos()
        {
            var response = new ProductoResponse();
            try
            {
                
                var objAD = new Producto_AD();
                var resultado = objAD.ObtenerProductos();
                if (resultado.Data.Count > 0)
                {
                    response.Result = true;
                    response.Data = resultado;
                    response.Mensaje = "Registros obtenidos correctamente.";
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }


        public ProductoResponse ObtenerProductosSegmento(ProductoRequest request)
        {
            var response = new ProductoResponse();
            try
            {

                var objAD = new Producto_AD();
                var resultado = objAD.ObtenerProductosSegmento(request);
                if (resultado.Data.Count > 0)
                {
                    response.Result = true;
                    response.Data = resultado;
                    response.Mensaje = "Registros obtenidos correctamente.";
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se encontraron registros.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }

        public SolicitudResponse RegistrarSolicitud(SolicitudResult request)
        {
            var response = new SolicitudResponse();
            try
            {

                var objAD = new Solicitud_AD();
                var resultado = objAD.RegistrarSolicitud(request);
                if (resultado!= null)
                {
                    response.Result = true;
                    response.Data = request;
                    response.Mensaje = "Registro realizado correctamente.";
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se pudo completar la operacion.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }

        public LogResponse RegistrarLog(LogResult request)
        {
            var response = new LogResponse();


            try
            {

                var objAD = new Log_AD();
                var resultado = objAD.RegistrarLog(request);
                if (resultado.Data!= null)
                {
                    response.Result = true;
                    response.Data = request;
                    response.Mensaje = "Registro realizado correctamente.";
                }
                else
                {
                    response.Result = false;
                    response.Mensaje = "No se pudo completar la operacion.";
                }
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Mensaje = ex.InnerException.ToString();
            }
            return response;
        }


        #region Correo
        public CorreoResponse EnviarToken(EnviarRequest request)
        {
            /*OBTENER DATA CLIENTE*/
            var objAD = new Token_AD();
            var BlComun = new ComunBL();
            var Cliente = objAD.ObtenerDatosCliente(request);

            Random random = new Random();
            string Codigo = random.Next(1000, 9999).ToString();

            var correoAsunto = request.Tipo == "A" ? "Código de verificación Multiproductos BANBIF" : "Código de verificación Multiproductos BANBIF";

            var CorreoRequest = new CorreoRequest
            {
                From = "BanBif Productos <BANBIFPRODUCTOS@banbif.com.pe>",
                To = Cliente.Correo,
                Asunto = correoAsunto,
                Mensaje = MensajeToken(Codigo, Cliente.Nombre, request.Tipo)
            };

            var RespuestaCorreo = BlComun.EnviarCorreo(CorreoRequest);
            if (RespuestaCorreo.Enviado == true)
            {
                var Token = new TokenRequest();
                Token.Documento = Cliente.Documento;
                Token.Token = int.Parse(Codigo);
                objAD.GuardarToken(Token);
            }

            return RespuestaCorreo;
        }

        public TokenResponse ValidarToken(TokenRequest request)
        {
            var objAD = new Token_AD();
            var data = objAD.ValidarToken(request);
            return data;
        }

        static string MensajeToken(string codigoValidacion, string nombreCliente, string tipo)
        {
            var strHTML = "";
            strHTML += "    <br><br>      <table bgcolor = '#e5e5e5' border = '0' cellpadding = '0' cellspacing = '0' style = 'border-collapse: collapse;font-family:arial;text-align: center;color: #515050;font-size: 16px;' width = '100%' >";
            strHTML += "                     <tr>";
            strHTML += "                         <td>";
            strHTML += "                           <table bgcolor = '#FFFFFF' border = '0' cellpadding = '0' cellspacing = '0' style = 'border-collapse: collapse;font-family:arial;text-align: center; font-size: 16px;width: 640px;' align = 'center' >";
            strHTML += "                                   <tr>";
            strHTML += "                                     <td align='center' valign='middle' style='border:none'><span style ='font-size:28px; font-family:arial;'><strong>";
            strHTML += "¡HOLA!, " + nombreCliente + "</strong></span></td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td height='15'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td width='570' style='font-size: 11px; text-align: justify; color:#303030; padding-left: 30px;' >";
            if (tipo == "A")
            {
                strHTML += "Ingresa el siguiente código para confirmar tu identidad: " + codigoValidacion + ".";
            }
            else
            {
                strHTML += "Ingresa el siguiente código para confirmar tu solicitud de desafiliación: " + codigoValidacion + ".";
            }
            strHTML += "<br><br>";
            strHTML += "Para garantizar la seguridad de tu correo electrónico, no respondas a este mensaje.";
            strHTML += "<br><br>";
            strHTML += "Atentamente,";
            strHTML += "<br><br>";
            strHTML += "Tu banco,";
            strHTML += "<br><br>";
            strHTML += "BANBIF";
            strHTML += "<br>";
            strHTML += "</span></td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td height='25'>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "<tr width='640'>";
            strHTML += "<td width='640'>";
            strHTML += "<img src='http://csbanbif.embluemail.com.s3.amazonaws.com/diciembre-030119-TC-Experiencia/6.png' width='640' border='0' style='display:block' >";
            strHTML += "</td>";
            strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td width='640'>";
            //strHTML += "<table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='640' style='border-collapse: collapse;font-family:arial' >";
            //strHTML += "<tr>";
            //strHTML += "<td width='35'>";
            //strHTML += "</td>";
            //strHTML += "<td width='570'>";
            //strHTML += "<table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='570' style='border-collapse: collapse;font-family:arial'>";
            //strHTML += "<tr>";
            //strHTML += "<td width='570' style='font-size: 11px; text-align: justify; color:#303030;' >";
            //strHTML += "<br>";
            //strHTML += "<p>El contenido de este mensaje es a título parcial y no es un folleto informativo. Prevalecen las definiciones de cada cobertura que se especifican en la póliza del Microseguro de Sepelio N° 420022607 contratada por CHUBB PERU. En caso de consultas, reclamos y/o siniestros llamar a la Central de Atención al Cliente de Chubb Perú al 417-5000 (Lima), escribe a atencion . seguros @ chubb . com , ingresa a la página web www . chubb . com . pe y/o visita la oficina ubicada en Calle Amador Merino Reyna N° 267 Oficina 402, San Isidro. Aplican exclusiones detalladas en la póliza. El plazo para la atención de consultas y/o reclamos es de 30 días contando desde la presentación del reclamo y/o consulta, sin que ello implique caducidad de su derecho. Para mayor información puedes ingresar a la página web www . BanBif . com . pe y/o www . Chubb. com / pe. Este seguro ofrecido por CHUBB PERU S.A. puede ser adquirido en las oficinas de BanBif. BanBif no se responsabiliza legalmente por la disponibilidad, idoneidad, calidad, condiciones, entrega, exclusiones, daño o perjuicio respecto a los seguros ofrecidos por CHUBB. La presente información es parcial y no constituye las condiciones de la Póliza, prevaleciendo los términos del contrato suscrito ante CHUBB y el adquirente del seguro. BanBif interviene en calidad de comercializador del Microseguro de Sepelio de CHUBB, conforme al Reglamento de Comercialización de Productos de Seguros Res. SBS N° 1121-2017, Ley Complementaria a la Ley de Protección al Consumidor en Materia de Servicios Financieros Ley N°28587 y sus normas modificatorias, así como el Reglamento de Gestión de Conducta de Mercado del Sistema Financiero aprobado por Res. SBS N°3274-2017 y sus modificatorias.</p>";
            //strHTML += "<br>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "<td width='35'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td>";
            //strHTML += "<table style='border: 0' align='center' width='100%' cellpadding='0' cellspacing='0' border='0' >";
            //strHTML += "<tbody>";
            //strHTML += "<tr >";
            //strHTML += "<td width='40'></td>";
            //strHTML += "<td width='550'>";
            //strHTML += "<table style='border: 0' align='center' width='100%' cellpadding='0' cellspacing='0' border='0' >";
            //strHTML += "<tbody>";
            //strHTML += "<tr>";
            //strHTML += "<td width='199' ></td>";
            //strHTML += "<td width='260' align='justify'><span style='color:#000000;font-size:10px;text-align:justify;font-family:arial;font-weight:bold;display:block'></span></td>";
            //strHTML += "<td width='90'><img src='https://ci4.googleusercontent.com/proxy/VnLNbt5DieoNSZDOvMi-kILz52bs8gecrKzcbReMoBa6CpsA9em4hbVvr1xrOrbPRzIjtHS8a7Vjq-SD5ghWUoK8DcpfFp_auYa8omThgNLOOtPKli129-T4hno=s0-d-e1-ft#http://i.embluejet.com/ImagenesMoxie/4569/images/Campana_seguros/ds-b.jpg' style = 'border:none' class='CToWUd'></td>";
            //strHTML += "</tr>";
            //strHTML += "</tbody>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "<td width='50'></td>";
            //strHTML += "</tr>";
            //strHTML += "</tbody>";
            //strHTML += "</table>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td width='640' height='10'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr width='640'>";
            //strHTML += "<td width='640'>";
            //strHTML += "<img src='http://csbanbif.embluemail.com.s3.amazonaws.com/diciembre-030119-TC-Experiencia/6.png' width='640' border='0' style='display:block'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            //strHTML += "<tr>";
            //strHTML += "<td width='640' height='10'>";
            //strHTML += "</td>";
            //strHTML += "</tr>";
            strHTML += "</table>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";

            return strHTML;
        }
        #endregion

    }
}
