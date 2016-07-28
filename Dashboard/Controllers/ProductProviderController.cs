using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class ProductProviderController : Controller
    {



        // GET: ProductProvider
        public ActionResult Index()
        {
            return View();
        }



        // GET: ProductProvider/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: ProductProvider/Create
        public ActionResult Create(int idProvider)
        {
            ViewBag.IdProvider = idProvider;

            return PartialView();
        }



        // POST: ProductProvider/Create
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



        // GET: ProductProvider/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductProvider/Edit/5
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

        // GET: ProductProvider/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductProvider/Delete/5
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
