using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETong.WebUI.Conponent.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            ViewBag.Message = "Hello, Portable Areas Test, good luck";
            return View();
        }

    }
}
