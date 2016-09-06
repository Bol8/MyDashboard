using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Interfaces;
using Repository;
using Domain.Manage;
using Domain.Models.StoreProductProvider;
using AutoMapper;

namespace Dashboard.Controllers
{
    public class TraceabilityController : Controller
    {
        private readonly IGenericRepository<Almacen_MateriaPrima> _gStoreProducProvider;
        private readonly IGenericRepository<MateriaPrima> _gProductProvider;
        private readonly IGenericRepository<Proveedores> _gProvider;


        public TraceabilityController(IGenericRepository<Almacen_MateriaPrima> gStoreProductProvider, IGenericRepository<MateriaPrima> gProductProvider, IGenericRepository<Proveedores> gProvider )
        {
            _gStoreProducProvider = gStoreProductProvider;
            _gProductProvider = gProductProvider;
            _gProvider = gProvider;

        }



        // GET: Traceability
        public ActionResult Index()
        {
            var list = _gStoreProducProvider.GetAll().ToList();
            var modelList = Mapper.Map<IEnumerable<Almacen_MateriaPrima>, IEnumerable<MStoreProductProvider>>(list).ToList();

            return View(modelList);
        }


        // GET: Traceability/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        [HttpGet]
        public ActionResult Create()
        {
            var model = new MStoreProductProviderCreate
            {
                ListProviders = new SelectList(_gProvider.GetAll().ToList(),"IdProveedor","RazonSocial"),
                ListProducts = new SelectList(_gProductProvider.GetAll().Where(x => x.IdProveedor == -1).ToList(), "Id", "Nombre")
            };

            return PartialView(model);
        }


        [HttpPost]
        public ActionResult GetProductForProvider(int idProvider)
        {
            var products = _gProductProvider.GetAll().Where(x => x.IdProveedor == idProvider)
                                                     .Select(x => new {id = x.IdProveedor, name = x.Nombre})
                                                     .OrderBy(x => x.name)
                                                     .ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

      
        [HttpPost]
        public ActionResult Create(Almacen_MateriaPrima element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView();
                }
                
                _gStoreProducProvider.Add(element);
                _gStoreProducProvider.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar añadir un registro de trazabilidad interna. " + ex);
            }
        }



        // GET: Traceability/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // POST: Traceability/Edit/5
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



        // GET: Traceability/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        // POST: Traceability/Delete/5
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
