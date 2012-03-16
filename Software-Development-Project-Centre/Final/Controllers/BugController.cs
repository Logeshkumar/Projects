using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final.Models;

namespace Final.Controllers
{
    public class BugController : Controller
    {
        //
        // GET: /Bug/
        private BugModel bug = new BugModel();

        public ActionResult Index()
        {
            string filepath = Server.MapPath("~\\App_Data\\XMLFile1.xml");
            var query = bug.Fill(filepath);
            return View(query);
        }

        //
        // GET: /Bug/Details/5

        public ActionResult Details(string id)
        {
            string filepath = Server.MapPath("~\\App_Data\\XMLFile1.xml");
            var query = bug.BugDetails(id, filepath);
            return View(query);
        }

        //
        // GET: /Bug/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Bug/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Bug/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Bug/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Bug/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Bug/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
