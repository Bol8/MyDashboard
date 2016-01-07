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



        [HttpGet]
        public ActionResult Details(int id)
        {


            return View();
        }



        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");

            return View();
        }



        [HttpPost]
        public ActionResult Create(Clientes client)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");

                return View(client);
            }

            if (!gClient.save(client)) throw new Exception("Error al intentar crear el cliente");

            return RedirectToAction("Index");

        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var client = gClient.getElementById(id);
            ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");

            return View(client);
        }





        [HttpPost]
        public ActionResult Edit(Clientes cliente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");

                return View(cliente);
            }

            if (!gClient.edit(cliente)) throw new Exception("Error al intentar modificar el cliente");

            return RedirectToAction("Index");
        }





        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = gClient.getElementById(id);

            return View(cliente);
        }





        [HttpPost]
        public ActionResult Delete(Clientes cliente)
        {
            if (!gClient.delete(cliente.IdCliente)) throw new Exception("Error al intentar eliminar el cliente");

            return RedirectToAction("Index");
        }
    }
}
