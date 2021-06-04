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
using Ganss.XSS;

namespace AbyssAzul.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Search()
        {
            var searchString = Request["search"];
            var sanitizer = new HtmlSanitizer();
            var newSearch = sanitizer.Sanitize(searchString);
            if (newSearch.Length > 200) RedirectToAction("Index", "Home");

            var search = new Search();
            search.Find(newSearch);

            if (search.Results.Count > 0)
            {
                ViewBag.Heading = "Search Results";
                ViewBag.Subheading = "Here's what we have...";
            }
            else
            {
                ViewBag.Heading = "Nothing Found";
                ViewBag.Subheading = "However, contact us and let's see what we can do...";
            }
                
            return View(search.Results);
        }
    }
}