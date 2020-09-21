using HouseMoverFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseMoverFinal.Controllers
{
    public class ServicesController : Controller
    {

        HouseMoverEntities instance = new HouseMoverEntities();
        // GET: HappyClient
        public ActionResult serviceList()
        {
            return View(instance.Services.ToList());
        }

        public ActionResult Viewservices()
        {
            return View(instance.Services.ToList());
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
        public ActionResult Create([Bind(Exclude = "id")] Service service)
        {
            if (!ModelState.IsValid)
                return View();
            instance.Services.Add(service);
            instance.SaveChanges();
            return RedirectToAction("serviceList");

        }

        // GET: HappyClient/Edit/5
        public ActionResult Edit(int id)
        {
            var C_ID = (from m in instance.Services where m.id == id select m).First();
            return View(C_ID);
        }

        // POST: HappyClient/Edit/5
        [HttpPost]
        public ActionResult Edit(Service C_Id)
        {

            var orignalRecord = (from m in instance.Services where m.id == C_Id.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(C_Id);

            instance.SaveChanges();
            return RedirectToAction("serviceList");

        }

        // GET: HappyClient/Delete/5
        public ActionResult Delete(Service C_Id)
        {
            var d = instance.Services.Where(x => x.id == C_Id.id).FirstOrDefault();
            instance.Services.Remove(d);
            instance.SaveChanges();
            return RedirectToAction("serviceList");
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
