using HouseMoverFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseMoverFinal.Controllers
{
    public class HomeController : Controller
    {
        HouseMoverEntities instance = new HouseMoverEntities();

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult viewQuery()
        {
          

            return View(instance.Contacts.ToList());
        }


        // GET: HappyClient/Delete/5
        public ActionResult Delete(Contact C_Id)
        {
            var d = instance.Contacts.Where(x => x.Id == C_Id.Id).FirstOrDefault();
            instance.Contacts.Remove(d);
            instance.SaveChanges();
            return RedirectToAction("viewQuery");
        }

        public ActionResult submitted()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult sendQuery(ContactField contact)
        {
            //Pass the data to store the record into the table 

            
            contact.sendMessage("insert into Contact(Name,Email,Message) values('" + contact.Name + "','"+contact.Email+"','" + contact.Message + "')");
            return View("submitted");




        }

    }
}