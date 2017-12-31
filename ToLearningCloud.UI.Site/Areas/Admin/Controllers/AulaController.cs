using AutoMapper;
using System;
using System.Collections.Generic;
using PagedList;
using System.Web.Mvc;
using ToLearningCloud.Application.Interfaces;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.UI.Site.Areas.Admin.ViewModels;
using ToLearningCloud.UI.Site.HtmlHelpers;

namespace ToLearningCloud.UI.Site.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Aula")]
    public class AulaController : Controller
    {
        private readonly IAulaAppService _aulaApp;
        private readonly IAssinaturaNivelAppService _assinaturaNivelApp;

        public AulaController(IAulaAppService aulaApp, IAssinaturaNivelAppService assinaturaNivelApp)
        {
            _aulaApp = aulaApp;
            _assinaturaNivelApp = assinaturaNivelApp;
        }

        // GET: Admin/Aula
        [Route("{page?}")]
        public ActionResult Index(int? page)
        {
            int paginaTamanho = 2; //de 10 para 2 apenas para testar com poucos registros
            int paginaNumero = (page ?? 1);

            IEnumerable<AulaViewModel> listAulaViewModel = Mapper.Map<IEnumerable<Aula>, IEnumerable<AulaViewModel>>(_aulaApp.GetByStatusAula("A,I"));

            ViewBag.page = page;

            return View(listAulaViewModel.ToPagedList(paginaNumero, paginaTamanho));
        }

        // GET: Admin/Aula/Details/5
        [Route("Detalhes/{id}/{titulo?}/{page?}")]
        public ActionResult Details(int id, int? page, string titulo)
        {
            Aula aula = _aulaApp.GetById(id);
            AulaViewModel aulaViewModel = Mapper.Map<Aula, AulaViewModel>(aula);
            ViewBag.page = page;

            if (aula.Aula_Titulo.ToSeoUrl() != titulo)
            {
                return RedirectToAction("Details", new { id, titulo = aula.Aula_Titulo.ToSeoUrl(), page });
                //return HttpNotFound("A aula que você está procurando não foi encontrada!");
            }

            return View(aulaViewModel);
        }

        // GET: Admin/Aula/Create
        [Route("Criar/{page?}")]
        public ActionResult Create(int? page)
        {
            ViewBag.assinaturanivel = new SelectList(_assinaturaNivelApp.GetByStatusAssinaturaNivel("A"), "AssinaturaNivel_Id", "AssinaturaNivel_Titulo");
            ViewBag.page = page;

            return View();
        }

        // POST: Admin/Aula/Create
        [HttpPost]
        [Route("Criar/{page?}")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AulaViewModel aula, int? page)
        {
            if (ModelState.IsValid)
            {
                Aula aulaDomain = Mapper.Map<AulaViewModel, Aula>(aula);

                _aulaApp.CreateAula(aulaDomain);

                return RedirectToAction("Index");
            }

            ViewBag.assinaturanivel = new SelectList(_assinaturaNivelApp.GetByStatusAssinaturaNivel("A"), "AssinaturaNivel_Id", "AssinaturaNivel_Titulo", aula.Aula_CodigoAssinaturaNivel);
            ViewBag.page = page;

            return View(aula);
        }

        // GET: Admin/Aula/Edit/5
        [Route("Alterar/{id}/{page?}")]
        public ActionResult Edit(int id, int? page, string returnaction)
        {
            Aula aula = _aulaApp.GetById(id);
            AssinaturaNivel assinaturaNivelAula = _assinaturaNivelApp.GetById(aula.Aula_CodigoAssinaturaNivel);
            AulaViewModel aulaViewModel = Mapper.Map<Aula, AulaViewModel>(aula);

            List<AssinaturaNivel> listAssinaturaNivel = new List<AssinaturaNivel>(_assinaturaNivelApp.GetByStatusAssinaturaNivel("A"));

            //SelectList listAssinaturaNivel = new SelectList(_assinaturaNivelApp.GetByStatusAssinaturaNivel("A"), "AssinaturaNivel_Id", "AssinaturaNivel_Titulo", aula.Aula_CodigoAssinaturaNivel);

            if (assinaturaNivelAula.AssinaturaNivel_Status == "I")
            {
                listAssinaturaNivel.Add(new AssinaturaNivel() { AssinaturaNivel_Id = assinaturaNivelAula.AssinaturaNivel_Id, AssinaturaNivel_Titulo = assinaturaNivelAula.AssinaturaNivel_Titulo });
            }

            SelectList selectlistAssinaturaNivel = new SelectList(listAssinaturaNivel, "AssinaturaNivel_Id", "AssinaturaNivel_Titulo", aula.Aula_CodigoAssinaturaNivel);

            if (returnaction == "" || returnaction == null)
            {
                returnaction = "Index";
            }


            ViewBag.assinaturanivel = selectlistAssinaturaNivel;
            ViewBag.ReturnAction = returnaction;
            ViewBag.page = page;

            return View(aulaViewModel);
        }

        // POST: Admin/Aula/Edit/5
        [HttpPost]
        [Route("Alterar/{id}/{page?}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AulaViewModel aula, int? page, string returnaction)
        {
            if (ModelState.IsValid)
            {
                Aula aulaDomain = Mapper.Map<AulaViewModel, Aula>(aula);

                _aulaApp.UpdateAula(aulaDomain);

                return RedirectToAction((string)returnaction, new { page = page });
            }

            Aula aulaOriginal = _aulaApp.GetById(aula.Aula_Id);
            AssinaturaNivel assinaturaNivelAula = _assinaturaNivelApp.GetById(aulaOriginal.Aula_CodigoAssinaturaNivel);

            List<AssinaturaNivel> listAssinaturaNivel = new List<AssinaturaNivel>(_assinaturaNivelApp.GetByStatusAssinaturaNivel("A"));

            if (assinaturaNivelAula.AssinaturaNivel_Status == "I")
            {
                listAssinaturaNivel.Add(new AssinaturaNivel() { AssinaturaNivel_Id = assinaturaNivelAula.AssinaturaNivel_Id, AssinaturaNivel_Titulo = assinaturaNivelAula.AssinaturaNivel_Titulo });
            }

            SelectList selectlistAssinaturaNivel = new SelectList(listAssinaturaNivel, "AssinaturaNivel_Id", "AssinaturaNivel_Titulo", aulaOriginal.Aula_CodigoAssinaturaNivel);

            ViewBag.assinaturanivel = selectlistAssinaturaNivel;
            ViewBag.ReturnAction = returnaction;
            ViewBag.page = page;

            return View(aula);
        }

        // GET: Admin/Aula/Delete/5
        [Route("Excluir/{id}/{page?}")]
        public ActionResult Delete(int id, int? page)
        {
            Aula aula = _aulaApp.GetById(id);
            AulaViewModel aulaViewModel = Mapper.Map<Aula, AulaViewModel>(aula);

            ViewBag.page = page;

            return View(aulaViewModel);
        }

        // POST: Admin/Aula/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Excluir/{id}/{page?}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aula aula = _aulaApp.GetById(id);

            _aulaApp.ChangeStatusAula(aula, "E");

            return RedirectToAction("Index");
        }

        // GET: Aula/Inactivate/5
        [Route("Inativar/{id}/{page?}")]
        public ActionResult Inactivate(int id, int? page)
        {
            Aula aula = _aulaApp.GetById(id);
            AulaViewModel aulaViewModel = Mapper.Map<Aula, AulaViewModel>(aula);

            ViewBag.page = page;

            return View(aulaViewModel);
        }

        // POST: Aula/Inactivate/5
        [HttpPost, ActionName("Inactivate")]
        [Route("Inativar/{id}/{page?}")]
        [ValidateAntiForgeryToken]
        public ActionResult InactivateConfirmed(int id, int? page)
        {
            Aula aula = _aulaApp.GetById(id);

            _aulaApp.ChangeStatusAula(aula, "I");

            return RedirectToAction("Index", new { page = page });
        }

        // GET: Aula/Activate/5
        [Route("Ativar/{id}")]
        public ActionResult Activate(int id, int? page)
        {
            Aula aula = _aulaApp.GetById(id);

            _aulaApp.ChangeStatusAula(aula, "A");

            return RedirectToAction("Index", new { page = page });
        }
    }
}
