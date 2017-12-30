namespace ToLearningCloud.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using ToLearningCloud.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.ToLearningCloudContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.ToLearningCloudContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.AssinaturaNivel.AddOrUpdate(
               asn => asn.AssinaturaNivel_Id,
               new AssinaturaNivel()
               {
                   AssinaturaNivel_Id = 1,
                   AssinaturaNivel_Titulo = "Assinatura Gratuita",
                   AssinaturaNivel_Descricao = "Assinatura Gratuita - Todos os usuário cadastrados através do site sem assinatura definida.",
                   AssinaturaNivel_Nivel = 10,
                   AssinaturaNivel_Status = "A"
               },
               new AssinaturaNivel()
               {
                   AssinaturaNivel_Id = 2,
                   AssinaturaNivel_Titulo = "Assinatura Básica",
                   AssinaturaNivel_Descricao = "Assinatura Básica - Usuários com acessos a conteúdos privilegiados",
                   AssinaturaNivel_Nivel = 20,
                   AssinaturaNivel_Status = "I"
               },
               new AssinaturaNivel()
               {
                   AssinaturaNivel_Id = 3,
                   AssinaturaNivel_Titulo = "Assinatura Premium",
                   AssinaturaNivel_Descricao = "Assinatura Premium - Usuários com acessos a todos os conteúdos",
                   AssinaturaNivel_Nivel = 30,
                   AssinaturaNivel_Status = "A"

               });

        }

    }
}
