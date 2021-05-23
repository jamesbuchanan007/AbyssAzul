using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbyssAzul.Models;

namespace AbyssAzul.Controllers
{
    public class RegionController : Controller
    {
        // GET: Region
        public ActionResult EcuadorPeru()
        {
            var product = new Product();
            var products = product.GetProductsByRegion("1");
            return View(products);
        }
        public ActionResult BrazilUruguay()
        {
            return View();
        }
        public ActionResult GuyanaSurinam()
        {
            return View();
        }
        public ActionResult ShrimpCamaron()
        {
            return View();
        }
        public ActionResult OtherSpecialties()
        {
            return View();
        }
    }
}