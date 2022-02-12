using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Modelos
{
    public partial class VehiculosContext : DbContext
    {

        public VehiculosContext()
        {
        }

        //Constructor con parametros para la configuracion
        public VehiculosContext(DbContextOptions options)
        : base(options)
        {
        }

        public virtual DbSet<ConteoVehiculosDB> Conteos { get; set; }
        public virtual DbSet<RecaudoVehiculoDB> Recaudos { get; set; }

        //Sobreescribimos el metodo OnConfiguring para hacer los ajustes que queramos en caso de
        //llamar al constructor sin parametros
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //En caso de que el contexto no este configurado, lo configuramos mediante la cadena de conexion
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=20.122.126.220; Database=Cacua;Uid=ccacua;Pwd=AP7ce2$_{\\DtNr,a;");
            }
        }

       
    }
}
