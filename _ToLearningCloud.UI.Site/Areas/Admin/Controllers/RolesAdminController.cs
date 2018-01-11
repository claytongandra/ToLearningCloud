using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToLearningCloud.Application.Interfaces;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Infra.CrossCutting.Identity.Configuration;
//using ToLearningCloud.Infra.CrossCutting.Identity.ViewModels.RolesAdminViewModels;

namespace ToLearningCloud.UI.Site.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Papel")]
    [Authorize(Roles = "Admin")]
    public class RolesAdminController : Controller
    {
        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;
        //private readonly IRoleAppService _roleApp;
        //private readonly IUsuarioRoleAppService _usuarioRoleApp;

        public RolesAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_roleApp = roleApp;
            //_usuarioRoleApp = usuarioRoleApp;
        }

        // GET: Admin/RolesAdmin
        [Route("Papeis/{status?}")]
        public ActionResult Index(int? status, string message)
        {

            ViewBag.Status = (status != null ? status : 0);
            ViewBag.StatusMessage = message;

            //IEnumerable<RoleViewModel> listRoleViewModel = Mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(_roleApp.GetAllRoles());

            //return View(listRoleViewModel);

            return View(_roleManager.Roles);
        }
    }
}