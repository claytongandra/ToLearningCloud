using System.Data.Entity;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Infra.Data.EntitiesConfig;

namespace ToLearningCloud.Infra.Data.Context
{
    class UsuarioToLearningCloudContext : DbContext

    {
        public UsuarioToLearningCloudContext()
            : base("ToLearningCloud")
        {

        }

        public DbSet<Usuario> NewLearningCloud_Usuario { get; set; }
        public DbSet<UsuarioAcesso> NewLearningCloud_UsuarioAcesso { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioAcessoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
