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
        public ActionResult Region(string regionId)
        {
            var isNum = int.TryParse(regionId, out var intRegionId);
            if(regionId.Length > 20 || !isNum) throw new Exception("Invalid Region ID");
            var region = new Regions(regionId);
            var r = region.GetRegion();
            ViewBag.RegionNameView = r.RegionNameView;
            ViewBag.ImgURL = r.ImgURL;

            var product = new Product();
            var products = product.GetProductsByRegion(regionId);
            return View(products);
        }
    }
}