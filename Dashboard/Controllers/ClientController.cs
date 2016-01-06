using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;

namespace Dashboard.Controllers
{
    public class ClientController : Controller
    {
        private gClient gClient;
        private gStatus gStatus;

        #region Constructors

        public ClientController()
        {
            gClient = new gClient();
            gStatus = new gStatus();
        }

        #endregion

    
        [HttpGet]
        public ActionResult Index()
        {
            var clientList = gClient.getElements();

            return View(clientList);
        }



        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(gStatus.getElements(), "idESTADOS", "Nombre");

            return View();
        }



        [HttpPost]
        public ActionResult Create(cliente client)
        {
            try
            {
                if (!ModelState.IsValid) return View(client);
                if (!gClient.save(client)) return HttpNotFound();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var client = gClient.getElementById(id);
            ViewBag.Estado = new SelectList(gStatus.getElements(), "idESTADOS", "Nombre");

            return View(client);
        }




        // POST: Client/Edit/5
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




        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }




        // POST: Client/Delete/5
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
