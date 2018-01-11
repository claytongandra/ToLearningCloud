using System;
using ToLearningCloud.Infra.CrossCutting.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ToLearningCloud.Infra.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}