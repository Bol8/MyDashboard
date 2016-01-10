using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;

namespace Dashboard.Controllers
{
    public class LineaPedidoCController : Controller
    {
        private gLineaPedidoC gLineaPedidoC;

        #region Constructors

        public LineaPedidoCController()
        {
            gLineaPedidoC = new gLineaPedidoC();
        }

        #endregion


        [HttpGet]
        public ActionResult Index(int numPed)
        {
            var orderLines = gLineaPedidoC.getElementsById(numPed);

            return PartialView(orderLines);
        }

        // GET: LineaPedidoC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int NumPed)
        {
            ViewBag.NumPed = NumPed;

            var st = getNameArticle();

            ViewBag.idArticulo = new SelectList(st, "idArt", "Nombre");


            return View();
        }




        // POST: LineaPedidoC/Create
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

        // GET: LineaPedidoC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LineaPedidoC/Edit/5
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

        // GET: LineaPedidoC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LineaPedidoC/Delete/5
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


        #region Private methods

        private dynamic getNameArticle()
        {
            gProduct gProduct = new gProduct();

            var st = gProduct.getElements().Select(
               s => new
               {
                   idArt = s.IdArticulo,
                   Nombre = s.Nombre + "   " + s.Peso + "gr."

               });

            return st;
        }


        #endregion


    }
}
