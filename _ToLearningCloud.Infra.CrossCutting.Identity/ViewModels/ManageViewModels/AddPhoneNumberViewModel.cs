using System.ComponentModel.DataAnnotations;

namespace ToLearningCloud.Infra.CrossCutting.Identity.ViewModels.ManageViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Celular.")]
        [Phone]
        [Display(Name = "Celular")]
        public string UsuarioAcesso_PhoneNumber { get; set; }
    }
}
