using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [AuthorizeAttribute(Roles = "Manager,Team Leader,Developer")]
        public ActionResult Index()
        {
            ViewData["Message"] = "Software Project Centre";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
