using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult PartiaViewTest()
		{
			return PartialView("Index");
		}
		public ActionResult FileTest(int? dl)
		{
			if(dl==1)
			{
				return File(Server.MapPath("/Images/內有惡犬.jpg"), "image/jpeg", "內有惡犬.jpg");
			}
			else
			{
				return File(Server.MapPath("/Images/內有惡犬.jpg"), "image/jpeg");
			}
		}
		public ActionResult JsonTest(int id)
		{
			repoProduct.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;
			var proudct = repoProduct.Find(id);
			return Json(proudct,JsonRequestBehavior.AllowGet);
		}
    }
}