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
        static Stack<string> myStack = new Stack<string>();
        public ActionResult Index()
        {
            return View();
        }

        //Function to add queue item
        public ActionResult AddItem()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.DisplayMessage = "Added 1 item to list.";
            return View("Index");
        }

        //Function to add queue items
        public ActionResult AddListItems()
        {
            myStack.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            }
            ViewBag.DisplayMessage = "Added 2000 items to list.";
            return View("Index");
        }

        //Function to display queue
        public ActionResult DisplayStack()
        {
            if(myStack.Count <=0)
            {
                ViewBag.DisplayMessage = "Stack is empty, there is nothing to display";
            }
            else
            {
                ViewBag.DisplayMessage = "Displaying Stack:";
                foreach (String str in myStack)
                {
                    ViewBag.myStack += str + " " + "<br>";
                }
            }
            //where this displays on the webpage is up to us. GREG doesn't like to view.
            return View("Index");
        }

        //Function to delete item from queue
        public ActionResult DeleteFromStack()
        {
            //if the count is 0 tell them there is nothing to delete
            //
            if (myStack.Count == 0)
            {
                ViewBag.DisplayMessage = "The Stack is empty. There is nothing to delete.";
            }
            else
            {
                myStack.Pop();
                ViewBag.DisplayMessage = "Item deleted from stack.";
            }
           
            return View("Index");
        }

        //Function to clear queue
        public ActionResult ClearStack()
        {
            if (myStack.Count == 0)
            {
                ViewBag.DisplayMessage = "The Stack is empty. There is nothing to clear.";
            }
            else
            {
                myStack.Clear();
                ViewBag.DisplayMessage = "Stack successfully cleared.";
            }
            return View("Index");
        }

        //Function to search queue
        public ActionResult SearchStack()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
           
            if (myStack.Count > 0)
            {
                string searchTerm = "New Entry 5";
                if (myStack.Contains(searchTerm))
                {
                    sw.Stop();
                    TimeSpan totalTime = sw.Elapsed;
                    ViewBag.isFound = "Found \"New Entry 5\"";
                    ViewBag.StopWatch = "Total time spent looking for New Entry 5: " + totalTime;
                }
                else
                {
                    sw.Stop();
                    TimeSpan totalTime = sw.Elapsed;
                    ViewBag.StopWatch = totalTime;
                    ViewBag.isFound = "Could not find \"New Entry 5\" in Stack";
                }
            }
            else
            {
                ViewBag.DisplayMessage = "Stack is empty, can not search for \"New Entry 5\"";
            }

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.StopWatch = ts;

            return View("Index");
        }
    }
}