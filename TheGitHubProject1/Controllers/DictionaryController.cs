using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheGitHubProject1.Controllers
{
    public class DictionaryController : Controller
    {
        // GET: Dictionary
        public Dictionary<int, int> theDictionary = new Dictionary<int, int>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddItem()
        {
            int numVariables = this.theDictionary.Count();
            this.theDictionary.Add(numVariables, numVariables + 1);

            ViewBag.Output = "<p>" + theDictionary[numVariables] + "</p>";

            return View("Index");
        }
    }
}