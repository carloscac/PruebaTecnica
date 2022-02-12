using Entidades;
using Negocio.Interfaces;
using Negocio.Interfaces.Repositorio;
using Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class Servicio : IServicioService
    {
        private IConsultaServicio _consultaServicio;
        private IRepositorio _repositorio;
        public Servicio(IConsultaServicio consultaServicio, IRepositorio repositorio)
        {
            _consultaServicio = consultaServicio;
            _repositorio = repositorio;
        }

        /// <summary>
        /// Método par aconsultar información del servicio
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaServicio<string>> ConsultaInformacion()
        {
            RespuestaServicio<string> respuestaServicio = new RespuestaServicio<string>();
            var token = await _consultaServicio.PostConsumoToken();
            //var datos = await _consultaServicio.ConsultaInformacion(token.token, DateTime.Now.AddDays(-2));
            InformacionServicio informacion = await ConsultarServicios(token.token);
            if (informacion != null)
            {
                await GuardadoInformacion(informacion);
                respuestaServicio = new RespuestaServicio<string>
                {
                    Mensaje = "Se realizo la consulta y guardado de la información entregada por el servicio",
                    Realizado = true
                };
            }
            else
            {
                respuestaServicio = new RespuestaServicio<string>
                {
                    Mensaje = "Se presentó un problema al consultar la información del servicio",
                    Realizado = false
                };
            }
            return respuestaServicio;
        }

        /// <summary>
        /// Método que se conecta con los servicios para obetener la información de los servicios
        /// </summary>
        /// <param name="token">Permiso para la obtención de información</param>
        /// <returns></returns>
        private async Task<InformacionServicio> ConsultarServicios(string token)
        {
            List<ConteoVehiculo> conteos = new List<ConteoVehiculo>();
            List<RecaudoVehiculos> recaudos = new List<RecaudoVehiculos>();
            for (int i = 0; i < 300; i++)
            {
                int iDiaValidar = i * -1;
                conteos.AddRange(await _consultaServicio.ConsultaInformacionConteo(token, DateTime.Now.AddDays(iDiaValidar)));
                recaudos.AddRange(await _consultaServicio.ConsultaInformacionRecaudo(token, DateTime.Now.AddDays(iDiaValidar)));
            }

            return new InformacionServicio { conteos = conteos, recaudos = recaudos };
        }

        /// <summary>
        /// Método con el cual se realizará el almacenamiento de la información
        /// </summary>
        /// <param name="informacion">Objeto con la información a guardar</param>
        /// <returns></returns>
        private async Task<bool> GuardadoInformacion(InformacionServicio informacion)
        {
            await _repositorio.InsertarConteo(informacion.conteos);
            await _repositorio.InsertarRecaudo(informacion.recaudos);
            return true;
        }

        /// <summary>
        /// Método para realizar la consulta de los recaudos guardados
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaServicio<List<RecaudoVehiculos>>> ListaRecaudos()
        {
            RespuestaServicio<List<RecaudoVehiculos>> respuesta = new RespuestaServicio<List<RecaudoVehiculos>>();
            try
            {
                List<RecaudoVehiculos> recaudos = new List<RecaudoVehiculos>();
                recaudos = await _repositorio.ListadoRecaudos();
                respuesta.Mensaje = "Se relacionan los resultados encontrados";
                respuesta.Realizado = true;
                respuesta.ObjetoRespuesta = recaudos;
            }
            catch (Exception Ex)
            {
                respuesta = new RespuestaServicio<List<RecaudoVehiculos>>
                {
                    Mensaje = Ex.Message,
                    Realizado = false
                };
            }
            return respuesta;
        }

        /// <summary>
        /// Método para realizar la consulta de la información necesaría para realizar el informe
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaServicio<List<ReporteAplicacion>>> ConsultaReporte()
        {
            RespuestaServicio<List<ReporteAplicacion>> respuesta = new RespuestaServicio<List<ReporteAplicacion>>();
            try
            {
                respuesta = new RespuestaServicio<List<ReporteAplicacion>>
                {
                    Mensaje = "Se realizó la consulta de información de forma correcta",
                    Realizado = true,
                    ObjetoRespuesta = await _repositorio.ConsultaReporte()
                };
            }
            catch (Exception)
            {
                respuesta = new RespuestaServicio<List<ReporteAplicacion>>
                {
                    Mensaje = "No se pudo obtener la información par la generación del reporte",
                    Realizado = false
                };
            }
            return respuesta;
        }
    }
}
