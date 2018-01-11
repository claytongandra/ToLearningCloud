using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Infra.CrossCutting.Identity.ViewModels
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            //userIdentity.AddClaim(new Claim("FullName", UsuarioAcesso_Usuario.Usuario_Nome + " " + UsuarioAcesso_Usuario.Usuario_SobreNome));
            userIdentity.AddClaims(new[] {
                new Claim("FullName", UsuarioAcesso_Usuario.Usuario_Nome + " " + UsuarioAcesso_Usuario.Usuario_SobreNome),

                new Claim("UserId",UsuarioAcesso_Usuario.Usuario_Id),
                new Claim("UserAccessId", Id),
                new Claim("Nivel", UsuarioAcesso_Nivel.ToString())

                                //new Claim("FirstName",UsuarioAcesso_Usuario.Usuario_Nome),
                //new Claim("Surname", UsuarioAcesso_Usuario.Usuario_SobreNome)
            });
            return userIdentity;
        }

        public int UsuarioAcesso_Nivel { get; set; }
        public virtual Usuario UsuarioAcesso_Usuario { get; set; }
    }
}