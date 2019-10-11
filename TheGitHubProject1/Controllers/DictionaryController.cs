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
        static Dictionary<int, int> myDictionary = new Dictionary<int, int>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddItem()
        {
            int numVariables = myDictionary.Count();
            myDictionary.Add(numVariables, numVariables + 1);

            ViewBag.Output = "<p>" + myDictionary[numVariables] + "</p>";

            return View("Index");
        }

        public ActionResult AddMultipleItems()
        {
            return View("Index");
        }

        public ActionResult DisplayItems()
        {

            return View("Index");
        }

        public 
    }
}