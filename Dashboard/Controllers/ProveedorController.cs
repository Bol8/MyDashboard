using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;
using Domain.Models.Proveedor;


namespace Dashboard.Controllers
{
    public class ProveedorController : Controller
    {
        private gProveedor gProvider;
        private gStatus gStatus;


        #region Constructors

        public ProveedorController()
        {
            gProvider = new gProveedor();
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
            var model = new mProveedorCreate();
            return View(model);
        }




        [HttpPost]
        public ActionResult Create(Proveedores proveedor)
        {
            if (!ModelState.IsValid)
            {
                var model = new mProveedorCreate(proveedor);

                return View(proveedor);
            }

            if (!gProvider.save(proveedor)) throw new Exception("Error al intentar crear el proveedor");

            return RedirectToAction("Index");
        }


        public ActionResult pruebaAjax()
        {
            if (Request.IsAjaxRequest())
            {
                var a = 1;
            }


            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new mProveedorCreate(gProvider.getElementById(id));

            return View(model);
        }



        [HttpPost]
        public ActionResult Edit(Proveedores provider)
        {
            if (!ModelState.IsValid)
            {
                var model = new mProveedorCreate(provider);
                return View(provider);
            }

            if (!gProvider.edit(provider)) throw new Exception("Error al intentar modificar el proveedor");

            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult DeleteConfirmed(int id)
        {
            var provider = new mProveedor(gProvider.getElementById(id));

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
