using Entidades;
using Negocio.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Negocio
{
    public class ConsultaServicio<T> : IServicioService
    {
        public Task<RespuestaServicio<string>> ConsultaInformacion()
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaServicio<List<ReporteAplicacion>>> ConsultaReporte()
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaServicio<List<RecaudoVehiculos>>> ListaRecaudos()
        {
            throw new NotImplementedException();
        }


        
    }
}
