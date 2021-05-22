using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbyssAzul.Models;

namespace AbyssAzul.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product()
        {
            //var product = new Product();

            return View();
        }
    }
}