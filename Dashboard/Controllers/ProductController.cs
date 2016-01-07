using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;

namespace Dashboard.Controllers
{
    public class ProductController : Controller
    {
        private gProduct gProduct;
        private gStatus gStatus;
        private gTypeProduct gTypeProduct;
        private gIVA gIva;

        #region Constructors

        public ProductController()
        {
            gProduct = new gProduct();
            gStatus = new gStatus();
            gTypeProduct = new gTypeProduct();
            gIva = new gIVA();
        }

        #endregion


        [HttpGet]
        public ActionResult Index()
        {
            var productList = gProduct.getElements();
            return View(productList);
        }



        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");
            ViewBag.IVA = new SelectList(gIva.getElements(), "IdIVA", "Porcentaje");
            ViewBag.Tipo = new SelectList(gTypeProduct.getElements(), "IdTipoProd", "Nombre");

            return View();
        }


        [HttpPost]
        public ActionResult Create(Articulos product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");
                ViewBag.IVA = new SelectList(gIva.getElements(), "IdIVA", "Porcentaje");
                ViewBag.Tipo = new SelectList(gTypeProduct.getElements(), "IdTipoProd", "Nombre");

                return View(product);
            }

            if (!gProduct.save(product)) throw new Exception("Error al intentar guardar el producto");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = gProduct.getElementById(id);

            ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");
            ViewBag.IVA = new SelectList(gIva.getElements(), "IdIVA", "Porcentaje");
            ViewBag.Tipo = new SelectList(gTypeProduct.getElements(), "IdTipoProd", "Nombre");

            return View(product);
        }



        [HttpPost]
        public ActionResult Edit(Articulos product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");
                ViewBag.IVA = new SelectList(gIva.getElements(), "IdIVA", "Porcentaje");
                ViewBag.Tipo = new SelectList(gTypeProduct.getElements(), "IdTipoProd", "Nombre");

                return View(product);
            }

            if (!gProduct.edit(product)) throw new Exception("Error al intentar modificar el producto");


            return RedirectToAction("Index");

        }

       
        public ActionResult DeleteConfirmed(int id)
        {

            return View();
        }

        // POST: Product/Delete/5
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
