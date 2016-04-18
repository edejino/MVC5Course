﻿using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
		static List<Product> products = new List<Product>
		{
			new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
			new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
			new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
		};

		public IEnumerable<Product> GetAllProducts()
		{
			return products;
		}

		public IHttpActionResult GetProduct(int id)
		{
			var product = products.FirstOrDefault((p) => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[ValidModel]
		public IHttpActionResult PostProduct(Product product)
		{
			if (ModelState.IsValid)
			{
				products.Add(product);
				return Created(Url.Route("DefaultApi", new { id = product.Id }), product);
			}
			return BadRequest(ModelState);
		}

		public IHttpActionResult DeleteProduct(int id)
		{
			var product = products.FirstOrDefault(p => p.Id == id);
			if (product == null) 
			{
				return NotFound();
			}
			products.Remove(product);
			return Ok(product);
		}
	}
}
