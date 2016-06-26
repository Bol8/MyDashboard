using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class PedidoProveedorController : Controller
    {
        // GET: PedidoProveedor
        public ActionResult Index()
        {
            return View();
        }

        // GET: PedidoProveedor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoProveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoProveedor/Create
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

        // GET: PedidoProveedor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoProveedor/Edit/5
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

        // GET: PedidoProveedor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoProveedor/Delete/5
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
