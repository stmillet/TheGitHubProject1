﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheGitHubProject1.Controllers
{
    public class StackController : Controller
    {
        // GET: Stack
        Stack<string> myStack = new Stack<string>();
        public ActionResult Index()
        {
            return View();
        }

        //Function to add queue item
        public ActionResult addItem()
        {
            myStack.Push("New Entry" + (myStack.Count + 1));

            return View("Index");
        }

        //Function to add queue items
        public ActionResult addListItems()
        {
            myStack.Clear();
            for (int iCount = 0; iCount <= 2000; iCount++)
            {
                myStack.Push("New Entry" + (myStack.Count + 1));
            }

            return View("Index");
        }

        //Function to display queue
        public ActionResult displayStack()
        {
            foreach (Object obj in myStack)
            {
                Console.WriteLine(obj);
            }

            return View("Index");
        }

        //Function to delete item from queue
        public ActionResult deleteFromStack()
        {

            return View("Index");
        }

        //Function to clear queue
        public ActionResult clearStack()
        {
            myStack.Clear();

            return View("Index");
        }

        //Function to search queue
        public ActionResult searchStack()
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