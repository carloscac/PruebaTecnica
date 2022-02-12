using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces.Repositorio
{
    public interface IRepositorio
    {
        Task<bool> InsertarConteo(List<ConteoVehiculo> lstConteos);
        Task<bool> InsertarRecaudo(List<RecaudoVehiculos> lstRecaudos);
        Task<List<RecaudoVehiculos>> ListadoRecaudos();
        Task<List<ReporteAplicacion>> ConsultaReporte();
      }
}
