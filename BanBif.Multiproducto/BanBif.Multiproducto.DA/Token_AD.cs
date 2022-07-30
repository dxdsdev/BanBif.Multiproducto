using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanBif.Multiproducto.BE.Token;
using BanBif.Multiproducto.BE.Correo;

namespace BanBif.Multiproducto.DA
{
    public class Token_AD
    {

        #region TOKEN
        public TokenResponse GuardarToken(TokenRequest request)
        {
            using (var db = new panelEntities())
            {
                var response = new TokenResponse();

                /*DESACTIVAR TOKEN NO VALIDADOS POR DNI*/
                var listaToken = db.MULTIPRODUCTOS_TOKEN.Where(p => p.DOCUMENTO == request.Documento && p.ESTADO == 1 && p.VALIDADO == false).ToList();

                foreach (var item in listaToken)
                {
                    item.ESTADO = 0;
                }
                db.SaveChanges();

                /*REGISTRAR NUEVO TOKEN*/
                var token = new MULTIPRODUCTOS_TOKEN
                {
                    DOCUMENTO = request.Documento,
                    TOKEN = request.Token,
                    FECHA = DateTime.Now,
                    VALIDADO = false,
                    ESTADO = 1
                };

                try
                {
                    db.MULTIPRODUCTOS_TOKEN.Add(token);
                    db.SaveChanges();
                    response.Result = true;

                    return response;
                }
                catch (Exception e)
                {
                    response.Result = false;
                    response.Mensaje = e.InnerException.ToString();
                    return response;
                }
            }
        }

        public TokenResponse ValidarToken(TokenRequest request)
        {
            using (var db = new panelEntities())
            {
                var response = new TokenResponse();
                var validarToken = request.Token;
                var token = db.MULTIPRODUCTOS_TOKEN.Where(p => p.DOCUMENTO == request.Documento && p.TOKEN == validarToken && p.ESTADO == 1 && p.VALIDADO == false).FirstOrDefault();
                /// TOKEN INVALIDO RETORNA FALSO Y EL MENSAJE
                if (token == null)
                {
                    response.Result = false;
                    response.Mensaje = "El token ingresado no es valido.";
                }
                else
                {
                    response.Result = true;
                    response.Mensaje = "El token ingresado es valido.";
                    token.VALIDADO = true;
                    db.SaveChanges();
                }


                return response;
            }
        }


        #endregion

        #region CORREO
        public CorreoDataCliente ObtenerDatosCliente(EnviarRequest request)
        {
            using (var db = new panelEntities())
            {
                var result = new CorreoDataCliente();
                var cliente = db.MULTIPRODUCTOS_CLIENTE.Where(p => p.clienteid == request.CodigoCliente).FirstOrDefault();
                if (cliente != null)
                {
                    result.Correo = cliente.mail;
                    result.Nombre = cliente.nombres + " " + cliente.apellidos;
                    result.Documento = cliente.dni;
                }

                return result;
            }

        }
        #endregion


    }
}
