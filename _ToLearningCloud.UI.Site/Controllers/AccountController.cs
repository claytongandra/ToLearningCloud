using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ToLearningCloud.Application.Interfaces;
using ToLearningCloud.Infra.CrossCutting.Identity.Configuration;
using ToLearningCloud.Infra.CrossCutting.Identity.Model;
//using ToLearningCloud.Infra.CrossCutting.Identity.ViewModels.AccountViewModels;

namespace ToLearningCloud.UI.Site.Controllers
{
    [Authorize]
    [RoutePrefix("Conta")]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly IUsuarioAcessoAppService _usuarioAcessoApp;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IUsuarioAcessoAppService usuarioAcessoApp)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_usuarioAcessoApp = usuarioAcessoApp;

        }

        // GET: /Account/Register
        [AllowAnonymous]
        [Route("Cadastrar")]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [Route("Cadastrar")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var user = new ApplicationUser
            //    {
            //        UserName = model.UsuarioAcesso_UserName,
            //        Email = model.UsuarioAcesso_Email,
            //        UsuarioAcesso_Nivel = 50,
            //        UsuarioAcesso_Usuario = new Domain.Entities.Usuario
            //        {
            //            Usuario_Nome = model.Usuario_Nome,
            //            Usuario_SobreNome = model.Usuario_SobreNome,
            //            Usuario_DataNascimento = model.Usuario_DataNascimento,
            //            Usuario_DataCadastro = DateTime.Now,
            //            Usuario_Status = "A"
            //        }
            //    };
            //    var result = await _userManager.CreateAsync(user, model.ConfirmPassword);
            //    if (result.Succeeded)
            //    {
            //        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            //        //////var code = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id);
            //        //////var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            //        //////await _userManager.SendEmailAsync(user.Id, "Confirme sua Conta", "Por favor confirme sua conta clicando neste link: <a href='" + callbackUrl + "'></a>");
            //        //////ViewBag.Link = callbackUrl;
            //        //////return View("DisplayEmail");
            //        return RedirectToAction("DisplayEmail", new { Id = user.Id });
            //    }
            //    AddErrors(result);
            //}


            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await _userManager.SendEmailAsync(user.Id, "Confirme sua Conta", "Por favor confirme sua conta clicando neste link: <a href='" + callbackUrl + "'></a>");
                    ViewBag.Link = callbackUrl;
                    return View("DisplayEmail");
                }
                AddErrors(result);
            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/DisplayEmail/Id
        [Route("Email/{Id}")]
        public async Task<ActionResult> DisplayEmail(string Id)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(Id);
            var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = Id, code = code }, protocol: Request.Url.Scheme);
            await _userManager.SendEmailAsync(Id, "Confirme sua Conta", "Por favor confirme sua conta clicando neste link: <a href='" + callbackUrl + "'></a>");
            ViewBag.Link = callbackUrl;

            return View();
        }


        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        [Route("Email/Confirmar/{userId}")]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        // GET: /Account/Login
        [AllowAnonymous]
        [Route("Entrar")]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [Route("Entrar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //string userName = _usuarioAcessoApp.GetLoginByEmailOrUser(model.UsuarioAcesso_UserName);

            //if (userName != null)
            //{
            //    model.UsuarioAcesso_UserName = userName;

            //    //////var user = await _userManager.FindByNameAsync(userName);
            //    //////if (user != null)
            //    //////{
            //    //////    if (!await _userManager.IsEmailConfirmedAsync(user.Id))
            //    //////    {
            //    //////        ViewBag.StatusMessage = "Você deve confirmar seu e-mail para poder entrar.";
            //    //////        return View("Error");
            //    //////    }
            //    //////}
            //}

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            ////var result = await _signInManager.PasswordSignInAsync(model.UsuarioAcesso_UserName, model.UsuarioAcesso_Password, model.UsuarioAcesso_RememberMe, shouldLockout: true);
            ////switch (result)
            ////{
            ////    case SignInStatus.Success:
            ////        return RedirectToLocal(returnUrl);
            ////    case SignInStatus.LockedOut:
            ////        return View("Lockout");
            ////    case SignInStatus.RequiresVerification:
            ////        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.UsuarioAcesso_RememberMe });
            ////    case SignInStatus.Failure:
            ////    default:
            ////        ModelState.AddModelError("", "Login ou Senha incorretos.");
            ////        model.UsuarioAcesso_Password = null;
            ////        return View(model);
            ////}
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Login ou Senha incorretos.");
                    return View(model);
            }
        }

        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [Route("Externa/Entrar")]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await _signInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // Se ele nao tem uma conta solicite que crie uma
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;

                    //get firstname, lastname and email address from login provider
                    var providerKey = loginInfo.Login.ProviderKey;
                    var loginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });

                    ////var addtionalDetail = await ExternalClaimsManager.GetAddtionalLoginDetailsAsync(
                    ////                                                    loginProvider,
                    ////                                                    AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie)
                    ////                                                    );


                    //// Pegar a informação do login externo.

                    ////var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                    ////if (info == null)
                    ////{
                    ////    return View("ExternalLoginFailure");
                    ////}

                    ////var user = new ApplicationUser
                    ////{

                    ////    UserName = loginInfo.DefaultUserName,
                    ////    Email = loginInfo.Email,
                    ////    UsuarioAcesso_Nivel = 50,
                    ////    EmailConfirmed = true,
                    ////    UsuarioAcesso_Usuario = new Domain.Entities.Usuario
                    ////    {
                    ////        Usuario_Nome = addtionalDetail.FirstName,
                    ////        Usuario_SobreNome = addtionalDetail.LastName,
                    ////        Usuario_DataCadastro = DateTime.Now,
                    ////        Usuario_Status = "A"
                    ////    }


                    ////};


                    //_userManager.UserValidator = new CustomUserValidator<ApplicationUser>(_userManager);

                    //if (String.IsNullOrEmpty(user.UserName))
                    //{
                    //    ModelState.AddModelError("UserName", "Preencha o campo Usuário.");
                    //}
                    //else
                    //////{
                    ////var existingAccount = await _userManager.FindByNameAsync(user.UserName);

                    ////if (existingAccount != null && existingAccount.Id != user.Id)
                    ////    ModelState.AddModelError("UsuarioAcesso_UserName", "O Usuário '" + user.UserName + "' já existe.");

                    ////var existingEmail = await _userManager.FindByEmailAsync(user.Email);

                    ////if (existingEmail != null && existingEmail.Id != user.Id)
                    ////{
                    ////    ModelState.AddModelError("UsuarioAcesso_Email", "O Email '" + user.Email + "' já existe.");
                    ////    user.EmailConfirmed = false;
                    ////}
                    //////}
                    ////if (ModelState.IsValid)
                    ////{
                    ////    var resultCreate = await _userManager.CreateAsync(user);
                    ////    if (resultCreate.Succeeded)
                    ////    {
                    ////        resultCreate = await _userManager.AddLoginAsync(user.Id, info.Login);
                    ////        if (resultCreate.Succeeded)
                    ////        {
                    ////            await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    ////            return RedirectToLocal(returnUrl);
                    ////        }
                    ////    }
                    ////    AddErrors(resultCreate);
                    ////}


                    ////return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UsuarioAcesso_UserName = user.UserName, Usuario_Nome = user.UsuarioAcesso_Usuario.Usuario_Nome, Usuario_SobreNome = user.UsuarioAcesso_Usuario.Usuario_SobreNome, UsuarioAcesso_Email = user.Email });

            }

        }

        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Pegar a informação do login externo.
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = info.Login.LoginProvider;

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ////var user = new ApplicationUser
            ////{
            ////    UserName = model.UsuarioAcesso_UserName,
            ////    Email = model.UsuarioAcesso_Email,
            ////    UsuarioAcesso_Nivel = 50,
            ////    UsuarioAcesso_Usuario = new Domain.Entities.Usuario
            ////    {
            ////        Usuario_Nome = model.Usuario_Nome,
            ////        Usuario_SobreNome = model.Usuario_SobreNome,
            ////        Usuario_DataCadastro = DateTime.Now,
            ////        Usuario_Status = "A"
            ////    }
            ////};

            //////    var existingAccount = await _userManager.FindByNameAsync(user.UserName);

            //////    if (existingAccount != null && existingAccount.Id != user.Id)
            //////        ModelState.AddModelError("UsuarioAcesso_UserName", "O Usuário '" + user.UserName + "' já existe.");

            //////    var existingEmail = await _userManager.FindByEmailAsync(user.Email);

            //////    if (existingEmail != null && existingEmail.Id != user.Id)
            //////    {
            //////        ModelState.AddModelError("UsuarioAcesso_Email", "O Email '" + user.Email + "' já existe.");
            //////        user.EmailConfirmed = false;
            //////    }

            //////    if (ModelState.IsValid)
            //////    {
            //////        var result = await _userManager.CreateAsync(user);
            //////        if (result.Succeeded)
            //////        {
            //////            result = await _userManager.AddLoginAsync(user.Id, info.Login);
            //////            if (result.Succeeded)
            //////            {
            //////                await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            //////                return RedirectToLocal(returnUrl);
            //////            }
            //////        }
            //////        AddErrors(result);
            //////    }
            //////}

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        [Route("Senha/Recuperar")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [Route("Senha/Recuperar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            ////if (ModelState.IsValid)
            ////{
            ////    ApplicationUser user = await _userManager.FindByEmailAsync(model.UsuarioAcesso_Email);

            ////    if (user == null)
            ////    {

            ////        ViewBag.Status = -1;
            ////        ViewBag.Message = "Não existe cadastro com o e-mail informado.";
            ////        return View("ForgotPasswordConfirmation");
            ////    }

            ////    if (string.IsNullOrEmpty(user.PasswordHash))
            ////    {
            ////        IList<UserLoginInfo> userLogins = await _userManager.GetLoginsAsync(user.Id);
            ////        if (userLogins.Count > 0)
            ////        {
            ////            model.CurrentLogins = userLogins;
            ////        }

            ////        ViewBag.Status = -1;
            ////        ViewBag.Message = "A conta solicitada não possui senha.";
            ////        return View("ForgotPasswordConfirmation", model);

            ////    }

            ////    //////if (user == null || !(await _userManager.IsEmailConfirmedAsync(user.Id)))
            ////    //////{
            ////    //////    // Não revelar se o usuario nao existe ou nao esta confirmado
            ////    //////    return View("ForgotPasswordConfirmation");
            ////    //////}

            ////    string code = await _userManager.GeneratePasswordResetTokenAsync(user.Id);
            ////    string callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            ////    await _userManager.SendEmailAsync(user.Id, "Esqueci minha senha", "Por favor altere sua senha clicando aqui: <a href='" + callbackUrl + "'></a>");
            ////    ViewBag.Link = callbackUrl;
            ////    ViewBag.Status = 0;
            ////    ViewBag.Message = "DEMO: Caso o link não chegue: ";
            ////    ViewBag.LinkAcesso = callbackUrl;
            ////    return View("ForgotPasswordConfirmation");
            ////}

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Não revelar se o usuario nao existe ou nao esta confirmado
                    return View("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await _userManager.SendEmailAsync(user.Id, "Esqueci minha senha", "Por favor altere sua senha clicando aqui: <a href='" + callbackUrl + "'></a>");
                ViewBag.Link = callbackUrl;
                ViewBag.Status = "DEMO: Caso o link não chegue: ";
                ViewBag.LinkAcesso = callbackUrl;
                return View("ForgotPasswordConfirmation");
            }

            // No caso de falha, reexibir a view. 
            return View(model);
        }

        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        [Route("Senha/Recuperar/Confirmar")]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // GET: /Account/ResetPassword
        [AllowAnonymous]
        [Route("Senha/Redefinir/{userId}")]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [Route("Senha/Redefinir/{userId}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ////var user = await _userManager.FindByEmailAsync(model.UsuarioAcesso_Email);
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Não revelar se o usuario nao existe ou nao esta confirmado
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            ////var result = await _userManager.ResetPasswordAsync(user.Id, model.Code, model.UsuarioAcesso_Password);
            var result = await _userManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        [Route("Senha/Redefinir/Confirmar")]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        // GET: /Account/SendCode
        [AllowAnonymous]
        [Route("Codigo")]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await _signInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                List<string> callbackError = new List<string>();

                callbackError.Add("Problemas ao identificar o usuário.");

                TempData["CallbackError"] = callbackError;

                return View("Error");
            }
            var userFactors = await _userManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [Route("Codigo")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await _signInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                List<string> callbackError = new List<string>();

                callbackError.Add("Problemas ao enviar o código de verificação.");

                TempData["CallbackError"] = callbackError;

                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        // GET: /Account/VerifyCode
        [AllowAnonymous]
        [Route("Codigo/Verificar")]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await _signInManager.HasBeenVerifiedAsync())
            {
                List<string> callbackError = new List<string>();

                callbackError.Add("Problemas ao verificar o código.");

                TempData["CallbackError"] = callbackError;

                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(await _signInManager.GetVerifiedUserIdAsync());
            if (user != null)
            {
                ViewBag.Status = "DEMO: Caso não chegue o " + provider + ". O código é: ";
                ViewBag.CodigoAcesso = await _userManager.GenerateTwoFactorTokenAsync(user.Id, provider);
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [Route("Codigo/Verificar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Código Inválido.");
                    return View(model);
            }
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        #endregion
    }
}