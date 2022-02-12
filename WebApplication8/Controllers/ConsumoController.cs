using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;
using Negocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication8.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ConsumoController : ControllerBase
    {
        private IServicioService _servicio;

        public ConsumoController(IServicioService servicioService)
        {
            _servicio = servicioService;
        }

        // GET: api/<ConsumoController>
        [HttpGet]
        public async Task<RespuestaServicio<string>> ConsultaInformacion()
        {
            var respuesta = await _servicio.ConsultaInformacion();
            return respuesta;
        }

        [HttpGet]
        public async Task<RespuestaServicio<List<RecaudoVehiculos>>> ListaRecaudos()
        {
            var respuesta = await _servicio.ListaRecaudos();
            return respuesta;
        }

        [HttpGet]
        public async Task<RespuestaServicio<List<ReporteAplicacion>>> InformacionReporte()
        {
            var respuesta = await _servicio.ConsultaReporte();
            return respuesta;
        }

    }
}
