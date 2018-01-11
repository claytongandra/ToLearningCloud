using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Infra.Data.EntitiesConfig
{
    public class UsuarioRoleConfiguration : EntityTypeConfiguration<UsuarioRole>
    {
        public UsuarioRoleConfiguration()
        {
            //HasKey(uro => uro.UsuarioRole_UsuarioCodigo);

            HasKey(uro => new { uro.UsuarioRole_UsuarioCodigo, uro.UsuarioRole_RoleCodigo });

            Property(uro => uro.UsuarioRole_UsuarioCodigo)
                .HasColumnName("UserId")
                .IsRequired()
                .HasMaxLength(128);

            Property(uro => uro.UsuarioRole_RoleCodigo)
               .HasColumnName("RoleId")
               .IsRequired()
                .HasMaxLength(128);

            ToTable("AspNetUserRoles");
        }
    }
}
