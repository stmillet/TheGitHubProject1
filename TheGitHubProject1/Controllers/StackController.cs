using System;
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
            myStack.Push("New Entry" + (myStack.Count + 1));
            ViewBag.DisplayMessage = "Added 1 item to list.";
            return View("Index");
        }

        //Function to add queue items
        public ActionResult AddListItems()
        {
            myStack.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry" + (myStack.Count + 1));
            }
            ViewBag.DisplayMessage = "Added 2000 items to list.";
            return View("Index");
        }

        //Function to display queue
        public ActionResult DisplayStack()
        {
            ViewBag.DisplayMessage = "Displaying Stack:";
            foreach (String str in myStack)
            {
                ViewBag.myStack += str + " "; 
            }
            return View("Index");
        }

        //Function to delete item from queue
        public ActionResult DeleteFromStack()
        {
            //ask the user which item they would like to add to stack (alertbox?)
            //
            ViewBag.DisplayMessage = "Item deleted from stack.";
            return View("Index");
        }

        //Function to clear queue
        public ActionResult ClearStack()
        {
            myStack.Clear();
            ViewBag.DisplayMessage = "Stack successfully cleared.";
            return View("Index");
        }

        //Function to search queue
        public ActionResult SearchStack()
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