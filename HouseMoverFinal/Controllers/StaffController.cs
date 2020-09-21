using HouseMoverFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseMoverFinal.Controllers
{
    public class StaffController : Controller
    {
        HouseMoverEntities instance = new HouseMoverEntities();
        // GET: HappyClient
        public ActionResult StaffList()
        {
            return View(instance.Staffs.ToList());
        }

        // GET: HappyClient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HappyClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HappyClient/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Staff staff)
        {
            if (!ModelState.IsValid)
                return View();
            instance.Staffs.Add(staff);
            instance.SaveChanges();
            return RedirectToAction("StaffList");

        }

        // GET: HappyClient/Edit/5
        public ActionResult Edit(int id)
        {
            var S_ID = (from m in instance.Staffs where m.id == id select m).First();
            return View(S_ID);
        }

        // POST: HappyClient/Edit/5
        [HttpPost]
        public ActionResult Edit(Staff C_Id)
        {

            var orignalRecord = (from m in instance.Staffs where m.id == C_Id.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(C_Id);

            instance.SaveChanges();
            return RedirectToAction("StaffList");

        }

        // GET: HappyClient/Delete/5
        public ActionResult Delete(Staff C_Id)
        {
            var d = instance.Staffs.Where(x => x.id == C_Id.id).FirstOrDefault();
            instance.Staffs.Remove(d);
            instance.SaveChanges();
            return RedirectToAction("StaffList");
        }

        // POST: HappyClient/Delete/5
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
