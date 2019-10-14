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
            int queueCount = myQueue.Count;
            foreach (var i in myQueue.ToArray())
            {
                if (queueCount > 0)
                {
                    ViewBag.Output = "<p>" + myQueue[i] + "</p>";
                }
                else
                {
                    ViewBag.Output = "There are no items in the Queue.";
                }
            }

            return View("Index");
        }

        //Function to delete item from queue
        public ActionResult deleteFromQueue()
        {
            if (myQueue.Count == 0)
            {
                Viewbag.Output = "The Dictionary is empty. There is nothing to display.";
            }
            else
            {
                myQueue.Dequeue();
                ViewBag.Output = "Removed the first Element from the Dictionary.";
            }
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
            string searchString = "New Entry 5";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            //loop to do all the work
            for (int iCount = 0; iCount < myQueue.Count; iCount++)
            {
                bool queueContains = myQueue.Contains(searchString);
                if (queueContains == "true")
                {
                    ViewBag.Output = "Queue contains the element searched for.";
                }
                else
                {
                    ViewBag.Output = "Queue does not contain the element searched for.";
                }
            }

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.StopWatch = ts;

            return View("Index");
        }
    }
}