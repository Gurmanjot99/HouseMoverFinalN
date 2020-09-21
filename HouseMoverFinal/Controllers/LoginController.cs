using HouseMoverFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseMoverFinal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult Valid()
        {
            return View();
        }

        public ActionResult inValid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult verfyLogin(LoginField login)
        {
            //Pass the data to store the record into the table 

            DataTable tbl = new DataTable();

            tbl = login.Login("select * from Admin where Name='" + login.userName + "'and Password='" + login.userPassword+ "'");

            if (tbl.Rows.Count > 0)
            {
                return View("Valid");
            }
            else
            {
                return View("inValid");
            }
        }



        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
