using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BanBif.Multiproducto.BE.Cliente;

namespace BanBif.Multiproducto.DA
{
    public class Cliente_AD
    {


        public ClienteResult ConsultarCLiente(ClienteRequest request)
        {
            using (panelEntities db = new panelEntities())
            {
                ClienteResult result = new ClienteResult();
                var data = db.SP_MULTIPRODUCTO_CONSULTAR_X_DNI(request.dni).FirstOrDefault();

                if (data != null)
                {

                    result.clienteid=data.clienteid;
                    result.dni=data.dni;
                    result.nombres=data.nombres;
                    result.mail=data.mail;
                    result.apellidos=data.apellidos;
                    result.segmento=data.segmento;
                    result.celular=data.celular;

                }
                else {
                    result=null;
                }
               
                return result;
            }

        }
    }
}
