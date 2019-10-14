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
        static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        public ActionResult Index()
        {
            ViewBag.Output = myDictionary;

            return View();
        }

        public ActionResult AddItem()
        {
            int numVariables = myDictionary.Count();
            myDictionary.Add(numVariables.ToString(), numVariables + 1);

            ViewBag.Output = "<p>" + myDictionary[numVariables.ToString()] + "</p>";

            return View("Index");
        }

        public ActionResult AddMultipleItems()
        {
            myDictionary.Clear();

            for(int iCount = 0; iCount < 2000; iCount++)
            {
                int theVar = iCount + 1;
                myDictionary.Add("New Entry " + theVar, theVar);
            }

            return View("Index");
        }

        public ActionResult DisplayItems()
        {

            return View("Index");
        }

        public ActionResult DeleteItems()
        {
            if(myDictionary.Count() == 0)
            {
                ViewBag.Output = "The Dictionary is empty. There is nothing to display.";
            }
            else
            {
                myDictionary.Remove(myDictionary.Keys.First());
                ViewBag.Output = "Removed the first Element from the Dictionary.";
            }

            return View("Index");
        }

        public ActionResult ClearItems()
        {
            myDictionary.Clear();
            ViewBag.Output = "The Dictionary has been cleared.";

            return View("Index");
        }

        public ActionResult SearchItems()
        {

            return View("Index");
        }
    }
}