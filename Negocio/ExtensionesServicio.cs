using Microsoft.Extensions.DependencyInjection;
using Negocio.Interfaces;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class ExtensionesServicio
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IServicioService, Servicio>();

        }
    }
}
