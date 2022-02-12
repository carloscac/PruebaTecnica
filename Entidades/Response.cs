using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Response
    {
        public bool IsSucces { get; set; }
        public string Message { get; set; }
        public string CodigoRespuesta { get; set; }
        public List<MensajesServicio> mensajesServicio { get; set; }
    }
}
