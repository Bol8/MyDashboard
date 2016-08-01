using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dashboard.ModelBinding;
using Domain.Models.Lote;

namespace Dashboard.Controllers
{
    public class LoteController : Controller
    {
        // GET: Lote
        public ActionResult Index()
        {
            return View();
        }

        // GET: Lote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lote/Create
        public ActionResult Create()
        {
            var list = new List<Person>();
            return View(list);
        }

        // POST: Lote/Create
        [HttpPost]
        public ActionResult Create(List<Person> persons )
        {
            try
            {
                //var a = listOfPersons;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lote/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lote/Edit/5
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

        // GET: Lote/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lote/Delete/5
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
