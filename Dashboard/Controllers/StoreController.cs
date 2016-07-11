using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Interfaces;
using Domain.Manage;
using Repository;
using Domain.Models.Articulo;
using Domain.Models.AlmacenProducto;
using AutoMapper;
using Dashboard.Models.Store;
using Dashboard.Models.Article;

namespace Dashboard.Controllers
{
    public class StoreController : Controller
    {
        #region Propiedades

        private IGenericRepository<Articulos> _gArticle;
        private IGenericRepository<Almacenes> _gStore;
        private IGenericRepository<Almacen_Productos> _gStoreArticle;
        private IGenericRepository<TipoProducto> _gArticleType;
        private IGenericRepository<Iva> _gIVA;
        private IGenericRepository<Estados> _gStatus;

        #endregion

        #region Constructores

        public StoreController(IGenericRepository<Articulos> gArticle, IGenericRepository<Almacenes> gStore,
                               IGenericRepository<TipoProducto> gArticleType, IGenericRepository<Iva> gIva,
                               IGenericRepository<Almacen_Productos> gStoreArticle, IGenericRepository<Estados> gStatus)
        {
            this._gArticle = gArticle;
            this._gStore = gStore;
            this._gArticleType = gArticleType;
            this._gIVA = gIva;
            this._gStatus = gStatus;
            this._gStoreArticle = gStoreArticle;
        }

        #endregion

        

        // GET: Store
        public ActionResult Index()
        {
            var store = _gStore.FindBy(x => x.Id == 1).FirstOrDefault();
            ViewBag.idStore = 1;
            var list = store.Almacen_Productos.ToList();
            var modelList = Mapper.Map<IEnumerable<Almacen_Productos>, IEnumerable<mAlmacenProducto>>(list).ToList();


            return View(modelList);
        }


        

       
        public ActionResult Create(int idStore)
        {
            var model = new mStoreArticleCreate(idStore);
            ViewBag.Estado = new SelectList(_gStatus.GetAll().ToList(), "Id", "Nombre");
            ViewBag.Tipo = new SelectList(_gArticleType.GetAll().ToList(), "Id", "Nombre");
            ViewBag.IVA = new SelectList(_gIVA.GetAll().ToList(), "Id", "Valor");

            return View(model);
        }


        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(mStoreArticleCreate model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Estado = new SelectList(_gStatus.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.Tipo = new SelectList(_gArticleType.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.IVA = new SelectList(_gIVA.GetAll().ToList(), "Id", "Valor");

                    return View(model);
                }
                
               //Damos de alta el articulo
               var article = Mapper.Map<mStoreArticleCreate, Articulos>(model);
               _gArticle.Add(article);
               _gArticle.Save();

               //Después lo referenciamos en el almacén
               var storeArticle = Mapper.Map<mStoreArticleCreate, Almacen_Productos>(model);
               storeArticle.Articulo = article.IdArticulo;
               _gStoreArticle.Add(storeArticle);
               _gStoreArticle.Save();
                
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar añadir un nuevo articulo al almacén. " + ex);
            }
        }



        // GET: Store/Edit/5
        public ActionResult Edit(int idStore , int idArticle)
        {
            var store = _gStore.FindBy(x => x.Id == idStore).FirstOrDefault();
            var article = store.Almacen_Productos.Where(x => x.Articulo == idArticle).FirstOrDefault();
            
            var model = Mapper.Map<Almacen_Productos, mStoreArticleCreate>(article);
            model.Estados = new SelectList(_gStatus.GetAll().ToList(), "Id", "Nombre");
            model.Ivas = new SelectList(_gIVA.GetAll().ToList(), "Id", "Valor");
            model.Tipos = new SelectList(_gArticleType.GetAll().ToList(), "Id", "Nombre");

            return View(model);
        }


        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(mStoreArticleCreate model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Estado = new SelectList(_gStatus.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.Tipo = new SelectList(_gArticleType.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.IVA = new SelectList(_gIVA.GetAll().ToList(), "Id", "Valor");

                    return View(model);
                }

                //Damos de alta el articulo
                var article = Mapper.Map<mStoreArticleCreate, Articulos>(model);
                _gArticle.Edit(article);
                _gArticle.Save();

                //Después lo referenciamos en el almacén
                var storeArticle = Mapper.Map<mStoreArticleCreate, Almacen_Productos>(model);
                _gStoreArticle.Edit(storeArticle);
                _gStoreArticle.Save();

                return RedirectToAction("Index");
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar editar un articulo del almacén. " + ex);
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
