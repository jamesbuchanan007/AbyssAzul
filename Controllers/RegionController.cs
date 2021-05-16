using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbyssAzul.Controllers
{
    public class RegionController : Controller
    {
        // GET: Region
        public ActionResult EcuadorPeru()
        {
            return View();
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