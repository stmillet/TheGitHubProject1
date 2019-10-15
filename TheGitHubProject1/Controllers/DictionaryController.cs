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

        //Method adds an item to the dictionary
        public ActionResult AddItem()
        {
            int numVariables = myDictionary.Count() + 1;
            myDictionary.Add("New Entry " + numVariables.ToString(), numVariables);
            ViewBag.DisplayMessage = "Added 1 item to list.";

            return View("Index");
        }

        //Method adds 2000 items to the dictionary after clearing it
        public ActionResult AddMultipleItems()
        {
            myDictionary.Clear();

            for(int iCount = 0; iCount < 2000; iCount++)
            {
                int theVar = iCount + 1;
                myDictionary.Add("New Entry " + theVar, theVar);
            }
            ViewBag.DisplayMessage = "Added 2000 items to list.";

            return View("Index");
        }

        //Method Displays the items in the Dictionary
        public ActionResult DisplayItems()
        {
            if(myDictionary.Count() > 0)
            {
                foreach(KeyValuePair<string, int> str in myDictionary)
                {
                    ViewBag.myDictionary +="Key: " +str.Key + ", Value: " + str.Value + "<br>";
                }
            }
            else
            {
                ViewBag.DisplayMessage = "Dictionary is empty, there is nothing to display";
            }

            return View("Index");
        }

        //Method Deletes the first item in the dictionary if it isn't empty
        public ActionResult DeleteItems()
        {
            if(myDictionary.Count() == 0)
            {
                ViewBag.DisplayMessage = "The Dictionary is empty. There is nothing to display.";
            }
            else
            {
                myDictionary.Remove(myDictionary.Keys.First());
                ViewBag.DisplayMessage = "Removed the first element from the dictionary.";
            }

            return View("Index");
        }

        //Method Clears the dictionary
        public ActionResult ClearItems()
        {
            myDictionary.Clear();
            ViewBag.DisplayMessage = "The Dictionary has been cleared.";

            return View("Index");
        }

        //Method searchs the dictionary for an item with the key: New Entry 5
        public ActionResult SearchItems()
        {
            if (myDictionary.Count() > 0)
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                string searchVar = "New Entry 5";
                if(myDictionary.ContainsKey(searchVar))
                {
                    ViewBag.DisplayMessage = "The dictionary contains a variable with a key \"New Entry 5\"";
                }
                else
                {
                    ViewBag.DisplayMessage = "The dictionary does NOT contain a variable with a key \"New Entry 5\"";
                }

                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                ViewBag.StopWatch = ts;
            }
            else
            {
                ViewBag.DisplayMessage = "The dicitionary is empty. Cannot search through it.";
            }
            return View("Index");
        }
    }
}