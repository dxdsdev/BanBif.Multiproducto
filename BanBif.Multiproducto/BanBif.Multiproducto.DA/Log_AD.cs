using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanBif.Multiproducto.BE.Log;

namespace BanBif.Multiproducto.DA
{
    public class Log_AD
    {

        public LogResponse RegistrarLog(LogResult request)
        {
            using (panelEntities db = new panelEntities())
            {

                LogResponse result = new LogResponse();
                var obj = db.SP_MULTIPRODUCTO_REGISTRAR_LOG(request.dni, request.accion, request.detalle);

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
