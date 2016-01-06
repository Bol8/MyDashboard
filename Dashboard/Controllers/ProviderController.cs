using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;


namespace Dashboard.Controllers
{
    public class ProviderController : Controller
    {
        private gProvider gProvider;
        private gStatus gStatus;


        #region Constructors

        public ProviderController()
        {
            gProvider = new gProvider();
            gStatus = new gStatus();
        }

        #endregion



        [HttpGet]
        public ActionResult Index()
        {
            var providerList = gProvider.getElements();
            return View(providerList);
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
        public ActionResult Create(Proveedores provider)
        {
            if (!ModelState.IsValid) return View(provider);
            if (!gProvider.save(provider)) throw new Exception("Error al intentar crear el proveedor");

            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult Edit(int id)
        {
            var provider = gProvider.getElementById(id);
            ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");

            return View(provider);
        }




        [HttpPost]
        public ActionResult Edit(Proveedores provider)
        {
            if (!ModelState.IsValid) return View(provider);
            if (!gProvider.edit(provider)) throw new Exception("Error al intentar modificar el proveedor");

            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult DeleteConfirmed(int id)
        {
            var provider = gProvider.getElementById(id);

            return View(provider);
        }




        [HttpPost]
        public ActionResult Delete(Proveedores provider)
        {
            if(!gProvider.delete(provider.IdProveedor)) throw new Exception("Error al intentar eliminar el proveedor");

            return RedirectToAction("Index");

        }
    }
}
