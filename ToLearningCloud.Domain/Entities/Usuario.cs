using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLearningCloud.Domain.Entities
{
    public class Usuario
    {
        //    public Usuario()
        //    {
        //        Usuario_Id = Guid.NewGuid().ToString();
        //    }

        //    public string Usuario_Id { get; set; }
        //    public string Usuario_Nome { get; set; }
        //    public string Usuario_SobreNome { get; set; }
        //    public DateTime? Usuario_DataNascimento { get; set; }
        //    public string Usuario_Genero { get; set; }
        //    public string Usuario_GeneroDescricao { get; set; }
        //    public string Usuario_FotoPerfil { get; set; }
        //    public string Usuario_Status { get; set; }
        //    public DateTime? Usuario_DataCadastro { get; set; }
        //
        public Usuario()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public virtual string Email { get; set; }

        public virtual bool EmailConfirmed { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string SecurityStamp { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual bool PhoneNumberConfirmed { get; set; }

        public virtual bool TwoFactorEnabled { get; set; }

        public virtual DateTime? LockoutEndDateUtc { get; set; }

        public virtual bool LockoutEnabled { get; set; }

        public virtual int AccessFailedCount { get; set; }

        public virtual string UserName { get; set; }
    }

}
