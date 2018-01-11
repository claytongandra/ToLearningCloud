using System.Data.Entity;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Infra.Data.EntitiesConfig;

namespace ToLearningCloud.Infra.Data.Context
{
    class ClaimsRolesNewLearningCloudContext : DbContext

    {
        public ClaimsRolesNewLearningCloudContext()
            : base("ToLearningCloud")
        {

        }

        public DbSet<Role> AspNetRoles { get; set; }
        public DbSet<UsuarioRole> AspNetUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RolesConfiguration());
            modelBuilder.Configurations.Add(new UsuarioRoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
