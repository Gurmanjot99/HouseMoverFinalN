using HouseMoverFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseMoverFinal.Controllers
{
    public class HappyClientController : Controller
    {
        HouseMoverEntities instance = new HouseMoverEntities();
        // GET: HappyClient
        public ActionResult HappyClients()
        {
            return View(instance.Clients.ToList());
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
        public ActionResult Create([Bind(Exclude = "id")] Client clent)
        {
            if (!ModelState.IsValid)
                return View();
            instance.Clients.Add(clent);
            instance.SaveChanges();
            return RedirectToAction("HappyClients");

        }

        // GET: HappyClient/Edit/5
        public ActionResult Edit(int id)
        {
            var C_ID = (from m in instance.Clients where m.id == id select m).First();
            return View(C_ID);
        }

        // POST: HappyClient/Edit/5
        [HttpPost]
        public ActionResult Edit(Client C_Id)
        {

            var orignalRecord = (from m in instance.Clients where m.id == C_Id.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(C_Id);

            instance.SaveChanges();
            return RedirectToAction("HappyClients");

        }

        // GET: HappyClient/Delete/5
        public ActionResult Delete(Client C_Id)
        {
            var d = instance.Clients.Where(x => x.id == C_Id.id).FirstOrDefault();
            instance.Clients.Remove(d);
            instance.SaveChanges();
            return RedirectToAction("HappyClients");
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
