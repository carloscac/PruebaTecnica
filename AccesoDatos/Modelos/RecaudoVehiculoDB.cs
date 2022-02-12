using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public partial class RecaudoVehiculoDB
    {
        [Key]
        public int idRecaudo { get; set; }
        public string estacion { get; set; }
        public string sentido { get; set; }
        public int hora { get; set; }
        public string categoria { get; set; }
        public int valorTabulado { get; set; }
        public DateTime fecha { get; set; }
    }
}
