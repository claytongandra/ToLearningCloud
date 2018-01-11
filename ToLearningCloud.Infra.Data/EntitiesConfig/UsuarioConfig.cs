using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Infra.Data.EntitiesConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);

            ToTable("AspNetUsers");
        }
    }
}