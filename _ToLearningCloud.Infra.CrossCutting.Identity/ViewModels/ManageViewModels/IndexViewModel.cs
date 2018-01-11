using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace ToLearningCloud.Infra.CrossCutting.Identity.ViewModels.ManageViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

    }
}
