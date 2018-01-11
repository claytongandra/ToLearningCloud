using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToLearningCloud.Domain.Interfaces.Repositories;

namespace ToLearningCloud.UI.Site.Areas.Admin.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(_usuarioRepository.ObterTodos());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            return View(_usuarioRepository.ObterPorId(id));
        }

        public ActionResult DesativarLock(string id)
        {
            _usuarioRepository.DesativarLock(id);
            return RedirectToAction("Index");
        }
    }
}