using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;
using Domain.Interfaces;
using Domain.Models.Proveedor;
using Domain.Models.ProductProvider;
using Domain.Connection;
using AutoMapper;

namespace Dashboard.Controllers
{
    public class ProveedorController : Controller
    {
        private IGenericRepository<Proveedores> _gProveedores;
        private IGenericRepository<Estados> _gStatus;
        private IGenericRepository<MateriaPrima> _gProductProvider;


        #region Constructors

        public ProveedorController(IGenericRepository<Proveedores> gProveedor,
                                   IGenericRepository<Estados> gStatus,
                                   IGenericRepository<MateriaPrima> gProductProvider
                                  )
        {
           this. _gProveedores = gProveedor;
           this. _gStatus = gStatus;
           this._gProductProvider = gProductProvider;
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


        #region Products

        public ActionResult Articles(int id)
        {
            var element = _gProveedores.FindBy(x => x.IdProveedor == id).FirstOrDefault();
            var articles = element.MateriaPrima.ToList();
            ViewBag.IdProvider = id;

            return PartialView(articles);
        }


        [HttpGet]
        public ActionResult CreateArticle(int idProvider)
        {
            var model = new mProductProvider();
            model.IdProveedor = idProvider;

            return PartialView(model);
        }



        [HttpPost]
        public ActionResult CreateArticle(MateriaPrima element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView();
                }

                _gProductProvider.Add(element);
                _gProductProvider.Save();

                var provider = _gProveedores.FindBy(x => x.IdProveedor == element.IdProveedor).FirstOrDefault();
                var articles = provider.MateriaPrima.ToList();
                ViewBag.IdProvider = element.IdProveedor;


                return PartialView("Articles" , articles);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar añadir un nuevo articulo al proveedor" + ex);
            }
            
        }
        
        [HttpGet]
        public ActionResult EditArticle(int idArticle)
        {
            var article = _gProductProvider.FindBy(x => x.Id == idArticle).FirstOrDefault();

            return PartialView(article);
        }


        [HttpPost]
        public ActionResult EditArticle(MateriaPrima element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView();
                }

                _gProductProvider.Edit(element);
                _gProductProvider.Save();

                var provider = _gProveedores.FindBy(x => x.IdProveedor == element.IdProveedor).FirstOrDefault();
                var articles = provider.MateriaPrima.ToList();
                ViewBag.IdProvider = element.IdProveedor;


                return PartialView("Articles", articles);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar editar un articulo de un proveedor" + ex);
            }
        }


        public ActionResult DeleteArticle(int idArticle)
        {
            try
            {
                var article = _gProductProvider.FindBy(x => x.Id == idArticle).FirstOrDefault();

                _gProductProvider.Delete(article);
                _gProductProvider.Save();

                var provider = _gProveedores.FindBy(x => x.IdProveedor == article.IdProveedor).FirstOrDefault();
                var articles = provider.MateriaPrima.ToList();
                ViewBag.IdProvider = article.IdProveedor;


                return PartialView("Articles", articles);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar un producto de proveedor" + ex);
            }
        }


        #endregion





        public ActionResult DeliveryNotes(int id)
        {
            var element = _gProveedores.FindBy(x => x.IdProveedor == id).FirstOrDefault();
            var deliveryNotes = element.Pedido_p.ToList();
            ViewBag.IdProvider = id;

            return PartialView(deliveryNotes);
        }

    }
}
