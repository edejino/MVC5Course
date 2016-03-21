using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : Controller
    {
		FabricsEntities db = new FabricsEntities();
		// GET: Test
		public ActionResult Index()
        {
            return View();
        }
		public ActionResult EDE()
		{
			return View();
		}
		[HttpPost]
		public ActionResult EDE(EDEViewModel data)
		{
			return View(data);
		}
		public ActionResult CreatProduct()
		{
			
			var product = new Product()
			{
				ProductName = "MBP",
				Active = true,
				Price = 2000,
				Stock = 5
			};

			db.Product.Add(product);
			db.SaveChanges();
			return View(product);
		}

		public ActionResult ReadProduct(bool? Active)
		{
			//var data = db.Product
			//	.Where(p => p.ProductId > 1550)
			//	.OrderByDescending(p => p.Price);
			//var data = db.Product.AsQueryable();
			var data = db.Product.OrderByDescending(p => p.Price).AsQueryable();
			data = data
				.Where(p => p.ProductId > 1550);
			//.OrderByDescending(p => p.Price);

			if (Active.HasValue)
			{
				data = data.Where(p => p.Active == Active);
			}

			return View(data);
		}
		public ActionResult OneProduct(int id)
		{
			//var data = db.Product.Find(id);
			//var data = db.Product.FirstOrDefault(p=>p.ProductId==id);
			var data = db.Product.Where(p=>p.ProductId==id).FirstOrDefault();
			
			return View(data);
		}

    }
}