using System;

namespace ToLearningCloud.Domain.Entities
{
    public class Aula
    {
        public int Aula_Id { get; set; }
        public string Aula_Titulo { get; set; }
        public string Aula_TipoConteudo { get; set; }
        public string Aula_Descricao { get; set; }
        public string Aula_Prerequisitos { get; set; }
        public string Aula_Imagem { get; set; }
        public string Aula_TempoVideo { get; set; }
        public string Aula_Video { get; set; }
        public string Aula_ConteudoEscrito { get; set; }
        public string Aula_Status { get; set; }
        public int Aula_CodigoAssinaturaNivel { get; set; }
        public virtual AssinaturaNivel Aula_AssinaturaNivel { get; set; }
        //public virtual int Aula_CodigoInstrutor { get; set; }
        //public virtual int Aula_CodigoOperadorCadastro { get; set; }
        public DateTime Aula_DataCadastro { get; set; }
        //public virtual int Aula_CodigoOperadorAlteracao { get; set; }
        public DateTime? Aula_DataAlteracao { get; set; }
        //public virtual ICollection<Curso> Aula_Cursos { get; set; }
    }
}
