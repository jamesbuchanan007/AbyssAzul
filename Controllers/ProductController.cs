using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbyssAzul.Models;
using Dapper;

namespace AbyssAzul.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product(string productId)
        {
            var product = new Product(productId);
            return View(product);
        }
    }
}