using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheGitHubProject1.Controllers
{
    public class QueueController : Controller
    {
        // GET: Queue
        Queue<string> myQueue = new Queue<string>();
        public ActionResult Index()
        {
            return View();
        }

        //Function to add queue item
        public ActionResult addItem()
        {
            myQueue.Enqueue("New Entry" + (myQueue.Count + 1));

            return View("Index");
        }

        //Function to add queue items
        public ActionResult addListItems()
        {
            myQueue.Clear();
            for (int iCount = 0; iCount <= 2000; iCount++)
            {
                myQueue.Enqueue("New Entry" + (myQueue.Count + 1));
            }

            return View("Index");
        }

        //Function to display queue
        public ActionResult displayQueue()
        {
            foreach (Object obj in myQueue)
            {
                ViewBag.Output = "<p>" + "Hello" + "</p>";
            }

            return View("Index");
        }

        //Function to delete item from queue
        public ActionResult deleteFromQueue()
        {

            return View("Index");
        }

        //Function to clear queue
        public ActionResult clearQueue()
        {
            myQueue.Clear();

            return View("Index");
        }

        //Function to search queue
        public ActionResult searchQueue()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            //loop to do all the work

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.StopWatch = ts;

            return View("Index");
        }
    }
}