using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.Multiproducto.BE.Correo
{
    public class CorreoRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public string AttachmentFileDir { get; set; }
        public string AttachmentFileName { get; set; }
    }
}
