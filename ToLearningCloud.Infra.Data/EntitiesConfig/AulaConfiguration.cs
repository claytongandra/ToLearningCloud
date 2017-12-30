using System.Data.Entity.ModelConfiguration;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Infra.Data.EntitiesConfig
{
    public class AulaConfiguration : EntityTypeConfiguration<Aula>
    {
        public AulaConfiguration()
        {

            HasKey(aul => aul.Aula_Id);

            Property(aul => aul.Aula_Id)
                .HasColumnName("aul_id")
                .IsRequired();

            Property(aul => aul.Aula_Titulo)
                .HasColumnName("aul_titulo")
                .IsRequired()
                .HasMaxLength(200);

            Property(aul => aul.Aula_TipoConteudo)
               .HasColumnName("aul_tipoconteudo")
               .IsRequired()
               .HasColumnType("char")
               .HasMaxLength(1);

            Property(aul => aul.Aula_Descricao)
                .HasColumnName("aul_descricao")
                .IsOptional()
                .HasMaxLength(8000);

            Property(aul => aul.Aula_Prerequisitos)
                .HasColumnName("aul_prerequisitos")
                .IsOptional()
                .HasMaxLength(8000);

            Property(aul => aul.Aula_Imagem)
                .HasColumnName("aul_imagemcapa")
                .IsOptional()
                .HasMaxLength(250);

            Property(aul => aul.Aula_Status)
                .HasColumnName("aul_status")
                .IsRequired()
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(aul => aul.Aula_TempoVideo)
                .HasColumnName("aul_videotempo")
                .IsOptional()
                .HasMaxLength(11);

            Property(aul => aul.Aula_Video)
                .HasColumnName("aul_videocaminho")
                .IsOptional()
                .HasMaxLength(250);

            Property(aul => aul.Aula_ConteudoEscrito)
                .HasColumnName("aul_conteudoescrito")
                .IsOptional()
                .IsMaxLength()
                .HasColumnType("varchar(max)");

            Property(aul => aul.Aula_DataCadastro)
                 .HasColumnName("aul_datacadastro")
                 .IsRequired()
                 .HasColumnType("datetime2");

            Property(aul => aul.Aula_DataAlteracao)
                .HasColumnName("aul_dataalteracao")
                .IsOptional()
                .HasColumnType("datetime2");

            Property(aul => aul.Aula_CodigoAssinaturaNivel)
               .HasColumnName("aul_fk_assinaturanivel");

            HasRequired(aul => aul.Aula_AssinaturaNivel)
                .WithMany()
                .HasForeignKey(aul => aul.Aula_CodigoAssinaturaNivel);

            ToTable("ToLearningCloud_Aula");

        }

    }
}
