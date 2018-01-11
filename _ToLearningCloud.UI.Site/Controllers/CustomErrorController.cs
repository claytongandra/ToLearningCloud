using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToLearningCloud.UI.Site.Controllers
{
    public class CustomErrorController : Controller
    {
        public ActionResult Oops()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}