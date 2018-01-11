using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Infra.Data.EntitiesConfig
{
    public class RolesConfiguration : EntityTypeConfiguration<Role>
    {
        public RolesConfiguration()
        {
            HasKey(rol => rol.Role_Id);

            Property(rol => rol.Role_Id)
                .HasColumnName("Id")
                 .IsRequired()
                 .HasMaxLength(128);

            Property(rol => rol.Role_Nome)
               .HasColumnName("Name")
               .IsRequired();

            ToTable("AspNetRoles");
        }
    }
}

