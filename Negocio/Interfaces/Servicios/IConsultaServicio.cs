using Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocio.Negocio
{
    public interface IConsultaServicio
    {
        Task<List<ConteoVehiculo>> ConsultaInformacionConteo(string token, DateTime fecha);
        Task<List<RecaudoVehiculos>> ConsultaInformacionRecaudo(string token, DateTime fecha);
        Task<RespuestaToken> PostConsumoToken();
    }
}