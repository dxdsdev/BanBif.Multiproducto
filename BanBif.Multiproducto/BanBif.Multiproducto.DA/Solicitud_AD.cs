using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanBif.Multiproducto.BE.Solicitud;

namespace BanBif.Multiproducto.DA
{
    public class Solicitud_AD
    {

        public SolicitudResponse RegistrarSolicitud(SolicitudResult request)
        {
            using (panelEntities db = new panelEntities())
            {

                SolicitudResponse result = new SolicitudResponse();
                var obj = db.SP_MULTIPRODUCTO_REGISTRAR_SOLICITUD(request.productoid, request.clienteid, request.ipcliente);

                

                if (obj==1)
                {
                    result.Mensaje="Guardado Correcto";
                    result.Result=true;
                    result.Data = request;
                }
                else
                {
                    result.Mensaje="Guardado Incorrecto";
                    result.Result=false;
                }

                return result;
            }

        }

    }
}
