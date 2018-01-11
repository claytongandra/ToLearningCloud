namespace ToLearningCloud.Infra.CrossCutting.Identity.Migrations
{
    using System.Data.Entity.Migrations;
    using ToLearningCloud.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ContextIdentity.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ContextIdentity.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            ////context.Users.AddOrUpdate(
            ////  asn => asn.Id,
            ////   new UsuarioAcesso()
            ////   {
            ////       UsuarioAcesso_Id = 1,
            ////        UsuarioAcesso_Nivel. = 10,
 

            ////   });
        }
    }
}
