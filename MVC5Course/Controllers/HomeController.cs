using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			// TODO:目前進度

			return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

			return View();
        }
		public ActionResult Test()
		{
			return View();
		}
    }
}