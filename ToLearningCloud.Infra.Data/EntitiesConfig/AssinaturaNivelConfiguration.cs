using System.Data.Entity.ModelConfiguration;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Infra.Data.EntitiesConfig
{
    public class AssinaturaNivelConfiguration : EntityTypeConfiguration<AssinaturaNivel>
    {
        public AssinaturaNivelConfiguration()
        {
            HasKey(asn => asn.AssinaturaNivel_Id);

            Property(asn => asn.AssinaturaNivel_Id)
                .HasColumnName("asn_id")
                .IsRequired();

            Property(asn => asn.AssinaturaNivel_Titulo)
                .HasColumnName("asn_titulo")
                .IsRequired()
                .HasMaxLength(150);

            Property(asn => asn.AssinaturaNivel_Descricao)
                .HasColumnName("asn_descricao")
                .IsRequired()
                .HasMaxLength(500);

            Property(asn => asn.AssinaturaNivel_Nivel)
                .HasColumnName("asn_nivel")
                .IsRequired();

            Property(asn => asn.AssinaturaNivel_Status)
                .HasColumnName("asn_status")
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(1);

            ToTable("ToLearningCloud_AssinaturaNivel");
        }
    }
}
