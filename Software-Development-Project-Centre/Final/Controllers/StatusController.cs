using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final.Models;

namespace Final.Controllers
{
    public class StatusController : Controller
    {
        //
        // GET: /Status/
        private FinalClassDataContext entity = new FinalClassDataContext();
        public ActionResult Index()
        {

            //List<Workpackstatus> st = new List<Workpackstatus>(); 
            //var d = (from req in entity.WorkPacRefs
            //        join status in entity.StatusReports
            //        on req.WorkPacRefId equals status.WorkPacRefId
            //        select new
            //        {
            //            status.StatusId,
            //            status.StatusText,
            //            status.StatusTitle,
            //            status.StatusDate,
            //            req.WorkPacRefTitle
            //        }).ToList();
            //foreach (var item in d)
            //{
            //    Workpackstatus stat = new Workpackstatus();
            //    stat.StatusId = item.StatusId;
            //    stat.StatusText = item.StatusText;
            //    stat.StatusTitle = item.StatusTitle;
            //    stat.StatusDate = item.StatusDate.ToString();
            //    stat.WorkPackTitle = item.WorkPacRefTitle;
            //    st.Add(stat);

            //}
            return View(entity.StatusReports.ToList());
        }

        //
        // GET: /Status/Details/5

        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var details = from req in entity.StatusReports
                          where req.StatusId == id
                          select req;
            return View(details.First());
        }

        //
        // GET: /Status/Create

        [AuthorizeAttribute(Roles = "Manager,Team Leader")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Status/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "StatusId")]StatusReport Stat)
        {
            try
            {
                // TODO: Add insert logic here

                entity.StatusReports.InsertOnSubmit(Stat);
                entity.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Status/Edit/5

        [AuthorizeAttribute(Roles = "Manager,Team Leader")]
        public ActionResult Edit(int id)
        {
            var _edit = from req in entity.StatusReports
                        where req.StatusId == id
                        select req;
            return View(_edit.First());
        }

        //
        // POST: /Status/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                var edit = entity.StatusReports.SingleOrDefault(c => c.StatusId == id);
                edit.StatusTitle = collection["StatusTitle"];
                edit.StatusDate = DateTime.Parse(collection["StatusDate"]);
                edit.StatusText = collection["StatusText"];
                edit.WorkPacRefId = Int32.Parse(collection["WorkPacRefId"]);
                var edit1 = entity.WorkPacRefs.SingleOrDefault(c => c.WorkPacRefId == edit.WorkPacRefId);
                if (edit1 == null)
                {
                    return RedirectToAction("Error");
                }
                else
                {
                    entity.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Status/Delete/5

        [AuthorizeAttribute(Roles = "Manager,Team Leader")]
        public ActionResult Delete(int id)
        {
            var _del = entity.StatusReports.SingleOrDefault(c => c.StatusId == id);

            return View(_del as StatusReport);
        }

        //
        // POST: /Status/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var del = entity.StatusReports.SingleOrDefault(c => c.StatusId == id);
                entity.StatusReports.DeleteOnSubmit(del);
                entity.SubmitChanges();
                return RedirectToAction("Index");

              
            }
            catch
            {
                return View();
            }
        }
    }
}
