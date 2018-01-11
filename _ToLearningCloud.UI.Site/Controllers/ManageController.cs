using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ToLearningCloud.Infra.CrossCutting.Identity.Configuration;
////using ToLearningCloud.Infra.CrossCutting.Identity.ViewModels.ManageViewModels;
using ToLearningCloud.Infra.CrossCutting.Identity.Model;

namespace ToLearningCloud.UI.Site.Controllers
{
    [Authorize]
    [RoutePrefix("Gerenciar")]
    public class ManageController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Manage
        [Route("Conta")]
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.Status = 0;

            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "A senha foi alterada com sucesso."
                : message == ManageMessageId.SetPasswordSuccess ? "A senha foi enviada com sucesso."
                : message == ManageMessageId.SetTwoFactorSuccess ? "A segunda validação foi enviada com sucesso."
                : message == ManageMessageId.Error ? "Ocorreu uma exceção ao processar sua solicitação."
                : message == ManageMessageId.AddPhoneSuccess ? "O Telefone foi adicionado com sucesso."
                : message == ManageMessageId.RemovePhoneSuccess ? "O Telefone foi removido com sucesso."
                : "";

            if (message == ManageMessageId.Error)
            {
                ViewBag.Status = -1;
            }

            var userId = User.Identity.GetUserId();
            var user = _userManager.FindById(userId);
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await _userManager.GetPhoneNumberAsync(userId),
                TwoFactor = await _userManager.GetTwoFactorEnabledAsync(userId),
                Logins = await _userManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId),
                ////Email = user.Email,
                ////EmailConfirmed = user.EmailConfirmed
            };
            return View(model);
        }

        // GET: /Manage/ChangePassword
        [Route("Conta/TrocarSenha")]
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Manage/ChangePassword
        [HttpPost]
        [Route("Conta/TrocarSenha")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //// var result = await _userManager.ChangePasswordAsync(User.Identity.GetUserId(), model.UsuarioAcesso_OldPassword, model.UsuarioAcesso_NewPassword);
            var result = await _userManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        // GET: /Manage/SetPassword
        [Route("Conta/CriarSenha")]
        public ActionResult SetPassword()
        {
            return View();
        }

        // POST: /Manage/SetPassword
        [HttpPost]
        [Route("Conta/CriarSenha")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                ////var result = await _userManager.AddPasswordAsync(User.Identity.GetUserId(), model.UsuarioAcesso_NewPassword);
                var result = await _userManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Manage/ManageLogins
        [Route("Conta/GerenciarLogins")]
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.Status = 0;

            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                List<string> callbackError = new List<string>();

                callbackError.Add("Problemas ao identificar o usuário.");

                TempData["CallbackError"] = callbackError;
                return View("Error");
            }

            if (message == ManageMessageId.Error)
            {
                ViewBag.Status = -1;
            }

            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "O login externo foi removido com sucesso."
                : message == ManageMessageId.Error ? "Ocorreu uma exceção ao processar sua solicitação."
                : message == ManageMessageId.LinkLoginSuccess ? "O login externo foi atribuído com sucesso."
                : "";

            var userLogins = await _userManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins,
                ////Callback = (List<string>)TempData["CallbackError"]
            });
        }

        // POST: /Manage/RemoveLogin
        [HttpPost]
        [Route("Conta/GerenciarLogins/Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await _userManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        // POST: /Manage/LinkLogin
        [HttpPost]
        [Route("Conta/GerenciarLogins/Atribuir")]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        // GET: /Manage/LinkLoginCallback
        [Route("Conta/GerenciarLogins/Atribuir/Retorno")]
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await _userManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);

            List<string> callbackError = new List<string>();
            foreach (string error in result.Errors)
            {
                callbackError.Add(error);
            }
            TempData["CallbackError"] = callbackError;
            return result.Succeeded ? RedirectToAction("ManageLogins", new { Message = ManageMessageId.LinkLoginSuccess }) : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        // GET: /Manage/AddPhoneNumber
        [Route("Conta/Celular")]
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [Route("Conta/Celular")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generate the token and send it
            ////var code = await _userManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.UsuarioAcesso_PhoneNumber);
            var code = await _userManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (_userManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    ////Destination = model.UsuarioAcesso_PhoneNumber,
                    Destination = model.Number,
                    Body = "Seu código de segurança é: " + code
                };
                await _userManager.SmsService.SendAsync(message);
            }
            ////return RedirectToAction("VerifyPhoneNumber", new { phoneNumber = model.UsuarioAcesso_PhoneNumber });
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        // GET: /Manage/VerifyPhoneNumber
        [Route("Conta/Celular/Verificar/{phoneNumber}")]
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            // This code allows you exercise the flow without actually sending codes
            // For production use please register a SMS provider in IdentityConfig and generate a code here.
            var code = await _userManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);

            ViewBag.Status = "DEMO: Caso o código não chegue via SMS o código é: ";
            ViewBag.CodigoAcesso = code;

            ////return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { UsuarioAcesso_PhoneNumber = phoneNumber });
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [Route("Conta/Celular/Verificar/{phoneNumber?}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ////var result = await _userManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.UsuarioAcesso_PhoneNumber, model.Code);
            var result = await _userManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }

            ViewBag.Status = "DEMO: Caso o código não chegue via SMS o código é: ";
            ViewBag.CodigoAcesso = model.Code;

            // No caso de falha, reexibir a view. 
            ModelState.AddModelError("", "Problemas ao adicionar celular.");

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }

            return View(model);
        }
                
        // GET: /Manage/RemovePhoneNumber
        [Route("Conta/Celular/Remover")]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await _userManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }

            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                if (!user.EmailConfirmed)
                {
                    await _userManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
                }

                await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        // POST: /Manage/RememberBrowser
        [HttpPost]
        //[Route("Conta/LembrarNavegador")]
        [ValidateAntiForgeryToken]
        public ActionResult RememberBrowser()
        {
            var rememberBrowserIdentity = AuthenticationManager.CreateTwoFactorRememberBrowserIdentity(User.Identity.GetUserId());
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, rememberBrowserIdentity);
            return RedirectToAction("Index", "Manage");
        }

        // POST: /Manage/ForgetBrowser
        [HttpPost]
        //[Route("Conta/EsquecerNavegador")]
        [ValidateAntiForgeryToken]
        public ActionResult ForgetBrowser()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
            return RedirectToAction("Index", "Manage");
        }

        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [Route("Conta/HabilitarDoisFatores")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await _userManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [Route("Conta/DesabilitarDoisFatores")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await _userManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
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

        private bool HasPassword()
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            LinkLoginSuccess,
            RemovePhoneSuccess,
            Error
        }
        #endregion
    }
}