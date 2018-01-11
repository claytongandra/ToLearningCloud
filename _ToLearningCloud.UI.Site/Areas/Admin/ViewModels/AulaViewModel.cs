using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.UI.Site.Areas.Admin.ViewModels
{
    public class AulaViewModel
    {
        [Key]
        public int Aula_Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Título.")]
        [StringLength(200, ErrorMessage = "O {0} deve possuir no mínimo {2} e máximo {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Título")]
        public string Aula_Titulo { get; set; }

        [DisplayName("Tipo Conteúdo")]
        [Required(ErrorMessage = "Informe o tipo do conteúdo.")]
        public string Aula_TipoConteudo { get; set; }

        [AllowHtml]
        [DisplayName("Descrição")]
        public string Aula_Descricao { get; set; }

        [AllowHtml]
        [DisplayName("Pré-requisitos")]
        public string Aula_Prerequisitos { get; set; }

        [DisplayName("Imagem")]
        public string Aula_Imagem { get; set; }

        [DisplayName("Tempo do Vídeo")]
        public string Aula_TempoVideo { get; set; }

        [DisplayName("Vídeo")]
        public string Aula_Video { get; set; }

        [AllowHtml]
        // [Column(TypeName = "varchar(MAX)"), MaxLength]
        [DisplayName("Conteúdo da Aula")]
        public string Aula_ConteudoEscrito { get; set; }

        [DisplayName("Status")]
        [Column(TypeName = "char")]
        [Required(ErrorMessage = "Informe o status da aula.")]
        public string Aula_Status { get; set; }

        [DisplayName("Disponível a partir")]
        [Required(ErrorMessage = "Selecione o nível de disponibilidade.")]
        public int Aula_CodigoAssinaturaNivel { get; set; }

        public virtual AssinaturaNivel Aula_AssinaturaNivel { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Aula_DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Aula_DataAlteracao { get; set; }
    }
}