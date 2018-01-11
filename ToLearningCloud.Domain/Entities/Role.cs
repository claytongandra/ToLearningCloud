using System.Collections.Generic;

namespace ToLearningCloud.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            //  Role_Id = Guid.NewGuid().ToString();
        }
        public string Role_Id { get; set; }
        public string Role_Nome { get; set; }

        public virtual ICollection<UsuarioRole> Role_UsuariosRoles { get; }

        //[NotMapped]
        //public virtual ICollection<UsuarioRole> Role_UsuariosRoles { get; set; }
    }
}
