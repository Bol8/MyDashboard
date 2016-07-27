using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;
using Domain.Interfaces;
using Domain.Models.Proveedor;
using Domain.Connection;
using AutoMapper;

namespace Dashboard.Controllers
{
    public class ProveedorController : Controller
    {
        private IGenericRepository<Proveedores> _gProveedores;
        private IGenericRepository<Estados> _gStatus;
        

        #region Constructors

        public ProveedorController(IGenericRepository<Proveedores> gProveedor,IGenericRepository<Estados> gStatus)
        {
            _gProveedores = gProveedor;
            _gStatus = gStatus;
        }

        #endregion



        [HttpGet]
        public ActionResult Index()
        {
            var list = _gProveedores.GetAll().ToList();
            var modelList = Mapper.Map<IEnumerable<Proveedores>, IEnumerable<mProveedor>>(list).ToList();

            return View(modelList);
        }




        [HttpGet]
        public ActionResult Details(int id)
        {
            var element = _gProveedores.FindBy(x => x.IdProveedor == id).FirstOrDefault();
            var model = Mapper.Map<Proveedores, mProveedor>(element);

            return View(model);
        }




        [HttpGet]
        public ActionResult Create()
        {
            var model = new mProveedorCreate();
            return View(model);
        }




        [HttpPost]
        public ActionResult Create(Proveedores element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var model = new mProveedorCreate(element);
                    return View(element);
                }

                _gProveedores.Add(element);
                _gProveedores.Save();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el proveedor. " + ex);
            }
            
            return RedirectToAction("Index");
        }

        


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var element = _gProveedores.FindBy(x => x.IdProveedor == id).FirstOrDefault();
            var model = new mProveedorCreate(element);
            //ViewBag.Estado = new SelectList(_gStatus.GetAll().ToList(), "Id", "Nombre");

            return View(model);
        }



        [HttpPost]
        public ActionResult Edit(Proveedores element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var model = new mProveedorCreate(element);
                    return View(element);
                }

                _gProveedores.Edit(element);
                _gProveedores.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el proveedor." + ex);
            }
            
            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult DeleteConfirmed(int id)
        {
            var element = _gProveedores.FindBy(x => x.IdProveedor == id).FirstOrDefault();
            var model = Mapper.Map<Proveedores, mProveedor>(element);

            return View(model);
        }




        [HttpPost]
        public ActionResult Delete(Proveedores element)
        {
            try
            {
                _gProveedores.Delete(element);
                _gProveedores.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar el cliente." + ex);
            }

            return RedirectToAction("Index");
        }



        public ActionResult Articles(int id)
        {
            var element = _gProveedores.FindBy(x => x.IdProveedor == id).FirstOrDefault();
            var articles = element.MateriaPrima.ToList();

            return PartialView(articles);
        }


    }
}
