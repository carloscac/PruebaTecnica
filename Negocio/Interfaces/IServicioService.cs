using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
   public interface IServicioService
    {
        Task<RespuestaServicio<string>> ConsultaInformacion();
        Task<RespuestaServicio<List<RecaudoVehiculos>>> ListaRecaudos();

        Task<RespuestaServicio<List<ReporteAplicacion>>> ConsultaReporte();
    }
}
