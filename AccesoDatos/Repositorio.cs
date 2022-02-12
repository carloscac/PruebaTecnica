using AccesoDatos.Modelos;
using Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Negocio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Repositorio : IRepositorio
    {
        private VehiculosContext _context;
        public Repositorio(VehiculosContext vehiculosContext)
        {
            _context = new VehiculosContext();
        }

        /// <summary>
        /// Método para realizar el guardado de la lista de conteos
        /// </summary>
        /// <param name="lstConteos">Listado obtenido del servicio</param>
        /// <returns></returns>
        public async Task<bool> InsertarConteo(List<ConteoVehiculo> lstConteos)
        {

            List<ConteoVehiculosDB> conteos = lstConteos.Select(e => new ConteoVehiculosDB
            {
                cantidad = e.cantidad,
                categoria = e.categoria,
                estacion = e.estacion,
                fecha = e.fecha,
                hora = e.hora,
                sentido = e.sentido
            }).ToList(); ;
            await _context.Conteos.AddRangeAsync(conteos);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Método para realizar el guardado de recaudos obtenidos del servicio
        /// </summary>
        /// <param name="lstRecaudos">Lista de recaudos obtenidos del servicio</param>
        /// <returns></returns>
        public async Task<bool> InsertarRecaudo(List<RecaudoVehiculos> lstRecaudos)
        {

            List<RecaudoVehiculoDB> recaudos = lstRecaudos.Select(e => new RecaudoVehiculoDB
            {
                valorTabulado = e.valorTabulado,
                categoria = e.categoria,
                estacion = e.estacion,
                fecha = e.fecha,
                hora = e.hora,
                sentido = e.sentido
            }).ToList(); ;
            await _context.Recaudos.AddRangeAsync(recaudos);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Método para obtener los recaudos que se tomaron desde el servicio
        /// </summary>
        /// <returns></returns>
        public async Task<List<RecaudoVehiculos>> ListadoRecaudos()
        {
            List<RecaudoVehiculos> recaudos = new List<RecaudoVehiculos>();
            recaudos = _context.Recaudos.Select(e => new RecaudoVehiculos
            {
                categoria = e.categoria,
                estacion = e.estacion,
                fecha = e.fecha,
                hora = e.hora,
                sentido = e.sentido,
                valorTabulado = e.valorTabulado
            }).ToList();


            return recaudos.ToList();
        }

        /// <summary>
        /// Método para obtener la información donde pueda visualizar el informe
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReporteAplicacion>> ConsultaReporte()
        {
            List<ReporteAplicacion> reportes = new List<ReporteAplicacion>();
            try
            {
                var conection = "Server=20.122.126.220; Database=Cacua;Uid=ccacua;Pwd=AP7ce2$_{\\DtNr,a;";
                using (SqlConnection sql = new SqlConnection(conection))
                {
                    using (SqlCommand command = new SqlCommand("PA_Reporte", sql))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        await sql.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                reportes.Add(MapToValue(reader));
                            }
                        }
                    }
                }

            }
            catch (Exception Ex)
            {
                reportes = new List<ReporteAplicacion>();
            }
            return reportes;
        }

        /// <summary>
        /// Método utilizado para realizar el mapeo del resultado obtenido por el SP
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private ReporteAplicacion MapToValue(SqlDataReader reader)
        {
            return new ReporteAplicacion()
            {
                fecha = (DateTime)reader["Fecha"],
                andesCantidad = (int)reader["ANDESCANTIDAD"],
                andesValor = (int)reader["ANDESVALOR"],
                fuscaCantidad = (int)reader["FUSCACANTIDAD"],
                fuscaValor = (int)reader["FUSCAVALOR"],
                uniSabanaCantidad = (int)reader["UNISABANACANTIDAD"],
                uniSabanaValor = (int)reader["UNISABANAVALOR"]
            };
        }

    }
}
