using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Infra.Data.EntitiesConfig;

namespace ToLearningCloud.Infra.Data.Context
{
    public class IdentityIsolationContext : DbContext
    {
        public IdentityIsolationContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
