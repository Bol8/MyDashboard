using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Interfaces;
using Domain.Manage;
using Repository;
using Domain.Models.Articulo;
using AutoMapper;

namespace Dashboard.Controllers
{
    public class StoreController : Controller
    {
        private IGenericRepository<Articulos> _gArticle;


        public StoreController(IGenericRepository<Articulos> gArticle)
        {
            this._gArticle = gArticle;
        }
        

        // GET: Store
        public ActionResult Index()
        {
            var list = _gArticle.GetAll().ToList();
            var modelList = Mapper.Map<IEnumerable<Articulos>, IEnumerable<mArticle>>(list).ToList();

            return View(modelList);
        }




        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
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

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
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

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
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
