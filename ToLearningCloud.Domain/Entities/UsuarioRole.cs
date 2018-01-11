namespace ToLearningCloud.Domain.Entities
{
    public class UsuarioRole
    {
        public string UsuarioRole_UsuarioCodigo { get; set; }
        public string UsuarioRole_RoleCodigo { get; set; }

        //////public virtual Role UsuarioRole_Role { get; set; }
        ////public virtual ICollection<Usuario> UsuarioRole_Usuarios { get; set; }
        ////public virtual ICollection<Role> UsuarioRole_Roles { get; set; }
    }
}
