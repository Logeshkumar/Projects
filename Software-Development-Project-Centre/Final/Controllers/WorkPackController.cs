using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final.Models;

namespace Final.Controllers
{
    public class WorkPackController : Controller
    {
        //
        // GET: /WorkPack/
        private FinalClassDataContext ent = new FinalClassDataContext();
        public ActionResult Index()
        {
            return View(ent.WorkPacRefs.ToList());
        }

        //
        // GET: /WorkPack/Details/5

        public ActionResult Details(int id)
        {
            var details = from req in ent.WorkPacRefs
                          where req.WorkPacRefId == id
                          select req;
            return View(details.First());
        }

        //
        // GET: /WorkPack/Create

        [AuthorizeAttribute(Roles = "Manager,Team Leader")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /WorkPack/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "WorkPacRefId")]WorkPacRef WorkPac)
        {
            try
            {
                // TODO: Add insert logic here

                ent.WorkPacRefs.InsertOnSubmit(WorkPac);
                ent.SubmitChanges();
                return RedirectToAction("Index"); ;
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /WorkPack/Edit/5

        [AuthorizeAttribute(Roles = "Manager,Team Leader")]
        public ActionResult Edit(int id)
        {
            var _edit = from req in ent.WorkPacRefs
                        where req.WorkPacRefId == id
                        select req;
            return View(_edit.First());
        }

        //
        // POST: /WorkPack/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                var edit = ent.WorkPacRefs.Single(c => c.WorkPacRefId == id);
                edit.WorkPacRefTitle = collection["WorkPacRefTitle"];
                edit.WorkPacRefDate = DateTime.Parse(collection["WorkPacRefDate"]);
                edit.WorkPacRefDesc = collection["WorkPacRefDesc"];
                ent.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /WorkPack/Delete/5

        [AuthorizeAttribute(Roles = "Manager,Team Leader")]
        public ActionResult Delete(int id)
        {
            var _del = ent.WorkPacRefs.SingleOrDefault(c => c.WorkPacRefId == id);

            return View(_del as WorkPacRef);
        }

        //
        // POST: /WorkPack/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var del = ent.WorkPacRefs.SingleOrDefault(c => c.WorkPacRefId == id);
                var del1 = ent.StatusReports.SingleOrDefault(c => c.WorkPacRefId == id);
                if (del1 != null)
                {
                    ent.StatusReports.DeleteOnSubmit(del1);
                    ent.WorkPacRefs.DeleteOnSubmit(del);
                    ent.SubmitChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ent.WorkPacRefs.DeleteOnSubmit(del);
                    ent.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
