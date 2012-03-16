using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final.Models;

namespace Final.Controllers
{
    public class SoftwareReqController : Controller
    {
        //
        // GET: /SoftwareReq/
        private FinalClassDataContext entity = new FinalClassDataContext();

        
        public ActionResult Index()
        {
            return View(entity.SoftwareRequirements.ToList());
        }

        //
        // GET: /SoftwareReq/Details/5

        public ActionResult Details(int id)
        {
            var details = from req in entity.SoftwareRequirements
                          where req.SoftReqId == id
                          select req;
            return View(details.First());
        }

        //
        // GET: /SoftwareReq/Create
        [AuthorizeAttribute(Roles="Manager,TeamLeader")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SoftwareReq/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "SoftReqId")]SoftwareRequirement SoftReq)
        {
            try
            {
                // TODO: Add insert logic here

                entity.SoftwareRequirements.InsertOnSubmit(SoftReq);
                entity.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /SoftwareReq/Edit/5

        [AuthorizeAttribute(Roles = "Manager,TeamLeader")]
        public ActionResult Edit(int id)
        {
            var _edit = from req in entity.SoftwareRequirements
                        where req.SoftReqId == id
                        select req;
            return View(_edit.First());
        }

        //
        // POST: /SoftwareReq/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                var edit = entity.SoftwareRequirements.Single(c => c.SoftReqId == id);
                edit.SoftReqTitle = collection["SoftReqTitle"];
                edit.SoftReqDate = DateTime.Parse(collection["SoftReqDate"]);
                edit.SoftReqSt = collection["SoftReqSt"];
                edit.Issue = collection["Issue"];
                entity.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SoftwareReq/Delete/5

        [AuthorizeAttribute(Roles = "Manager,TeamLeader")]
        public ActionResult Delete(int id)
        {
            var _del = entity.SoftwareRequirements.SingleOrDefault(c => c.SoftReqId == id);

            return View(_del as SoftwareRequirement);
        }

        //
        // POST: /SoftwareReq/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var del = entity.SoftwareRequirements.SingleOrDefault(c => c.SoftReqId == id);
                entity.SoftwareRequirements.DeleteOnSubmit(del);
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
