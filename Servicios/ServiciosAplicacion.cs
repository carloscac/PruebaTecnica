using Entidades;
using Negocio.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServiciosAplicacion : IConsultaServicio
    {

        /// <summary>
        /// Método para realizar el consumo del token con el que solicitaremos la información
        /// que se almacenará en la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<RespuestaToken> PostConsumoToken()
        {
            RespuestaToken response = new RespuestaToken();
            try
            {

                var urlBase = "http://190.145.81.67:5200/api";

                UsuarioConexion usuario = new UsuarioConexion { password = "1234", userName = "user" };

                var url = urlBase + "/Login";


                var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

                using (HttpClient cliente = new HttpClient())
                {
                    try
                    {
                        var responseT = await cliente.PostAsync(url, content).ConfigureAwait(false);
                        var jsonResultT = await responseT.Content.ReadAsStringAsync();
                        response = JsonConvert.DeserializeObject<RespuestaToken>(jsonResultT);

                    }
                    catch (Exception Ex)
                    {

                        response = new RespuestaToken
                        {
                            token = string.Empty,
                            expiration = default(DateTime)

                        };
                    }
                }
            }
            catch (Exception Ex)
            {

                response = new RespuestaToken
                {
                    token = string.Empty,
                    expiration = default(DateTime)

                };
            }
            return response;
        }

        /// <summary>
        /// Método para consultar la información de conteo de vehículos
        /// </summary>
        /// <param name="token">Token para poder realizar el consumo</param>
        /// <param name="fecha">Fecha de la consulta realizada</param>
        /// <returns></returns>
        public async Task<List<ConteoVehiculo>> ConsultaInformacionConteo(string token, DateTime fecha)
        {
            List<ConteoVehiculo> respuesta = new List<ConteoVehiculo>();
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    string url = $"http://190.145.81.67:5200/api/ConteoVehiculos/{fecha.ToString("yyyy-MM-dd")}";

                    cliente.BaseAddress = new Uri(url);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                    var response = await cliente.GetAsync(cliente.BaseAddress);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        response.EnsureSuccessStatusCode();
                        var jsonResult = await response.Content.ReadAsStringAsync();
                        var newRespuesta = JsonConvert.DeserializeObject<List<ConteoVehiculo>>(jsonResult);
                        respuesta = newRespuesta.Select(e => new ConteoVehiculo
                        {
                            cantidad = e.cantidad,
                            categoria = e.categoria,
                            estacion = e.estacion,
                            fecha = fecha,
                            hora = e.hora,
                            sentido = e.sentido
                        }).ToList();
                    }

                }
            }
            catch (Exception)
            {
                respuesta = new List<ConteoVehiculo>();
            }
            return respuesta;

        }

        /// <summary>
        /// Método para consultar la información de recaudo por vehículos
        /// </summary>
        /// <param name="token">Token para poder realizar el consumo</param>
        /// <param name="fecha">Fecha de la consulta realizada</param>
        /// <returns></returns>
        public async Task<List<RecaudoVehiculos>> ConsultaInformacionRecaudo(string token, DateTime fecha)
        {
            List<RecaudoVehiculos> respuesta = new List<RecaudoVehiculos>();
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    string url = $"http://190.145.81.67:5200/api/RecaudoVehiculos/{fecha.ToString("yyyy-MM-dd")}";

                    cliente.BaseAddress = new Uri(url);
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                    var response = await cliente.GetAsync(cliente.BaseAddress);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        response.EnsureSuccessStatusCode();
                        var jsonResult = await response.Content.ReadAsStringAsync();
                        var newRespuesta = JsonConvert.DeserializeObject<List<RecaudoVehiculos>>(jsonResult);
                        respuesta = newRespuesta.Select(e => new RecaudoVehiculos
                        {
                            categoria = e.categoria,
                            estacion = e.estacion,
                            fecha = fecha,
                            hora = e.hora,
                            sentido = e.sentido,
                            valorTabulado = e.valorTabulado
                        }).ToList();
                    }

                }
            }
            catch (Exception)
            {
                respuesta = new List<RecaudoVehiculos>();
            }
            return respuesta;

        }

    }
}
