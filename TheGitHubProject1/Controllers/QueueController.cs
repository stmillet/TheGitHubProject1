﻿using System;
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
            ViewBag.DisplayMessage = "Added 1 item to queue.";

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
            ViewBag.DisplayMessage = "Added 2000 items to queue.";
            return View("Index");
        }

        //Function to display queue
        public ActionResult displayQueue()
        {
            int queueCount = myQueue.Count;
            ViewBag.DisplayMessage = "Displaying Queue:";
            foreach (String str in myQueue)
            {
                if (queueCount > 0)
                {
                    ViewBag.myQueue += str + " ";
                }
                else
                {
                    ViewBag.DisplayMessage = "There are no items in the Queue.";
                }
            }

            return View("Index");
        }

        //Function to delete item from queue
        public ActionResult deleteFromQueue()
        {
            if (myQueue.Count == 0)
            {
                ViewBag.DisplayMessage = "The Queue is empty. There is nothing to display.";
            }
            else
            {
                myQueue.Dequeue();
                ViewBag.DisplayMessage = "Item deleted from stack.";
            }
            return View("Index");
        }

        //Function to clear queue
        public ActionResult clearQueue()
        {
            myQueue.Clear();
            ViewBag.DisplayMessage = "Queue successfully cleared.";
            return View("Index");
        }

        //Function to search queue
        public ActionResult searchQueue()
        {
            if (myQueue.Count() > 0)
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                string searchString = "New Entry 5";
                if (myQueue.Contains(searchString))
                {
                    ViewBag.DisplayMessage = "The queue contains a variable with a key \"New Entry 5\"";
                }
                else
                {
                    ViewBag.DisplayMessage = "The queue does NOT contain a variable with a key \"New Entry 5\"";
                }

                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                ViewBag.StopWatch = ts;
            }
            return View("Index");
        }
    }
}