using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Connection;
using Repository;
using Domain.Manage;
using Domain.Interfaces;
using Domain.Models.Articulo;

namespace Dashboard.Controllers
{
    public class ArticleController : Controller
    {
        private IGenericRepository<Articulos> _gArticle;
        private IGenericRepository<TipoProducto> _gArticleType;
        private IGenericRepository<Iva> _gIVA;
        private IGenericRepository<Estados> _gStatus;

        #region Constructors

        public ArticleController(IGenericRepository<Articulos> gArticle,
                                 IGenericRepository<TipoProducto> gArticleType,
                                 IGenericRepository<Iva> gIVA,
                                 IGenericRepository<Estados> gStatus)
        {
            this._gArticle = gArticle;
            this._gArticleType = gArticleType;
            this._gIVA = gIVA;
            this._gStatus = gStatus;
         
        }
        #endregion


        //[HttpGet]
        //public ActionResult Index()
        //{
        //    var list = _gClient.GetAll().ToList();
        //    var modelList = Mapper.Map<IEnumerable<Clientes>, IEnumerable<mCliente>>(list).ToList();

        //    return View(modelList);
        //}



        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Estado = new SelectList(_gStatus.GetAll().ToList(), "Id", "Nombre");
            ViewBag.Tipo = new SelectList(_gArticleType.GetAll().ToList(), "Id", "Nombre");
            ViewBag.IVA = new SelectList(_gIVA.GetAll().ToList(), "Id", "Valor");

            return View();
        }



        [HttpPost]
        public ActionResult Create(Articulos element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var model = AutoMapper.Mapper.Map<Articulos, mArticle>(element);

                    return View(model);
                }

                _gArticle.Add(element);
                _gArticle.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el cliente. " + ex);
            }

            return RedirectToAction("Index","Store");

        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var element = _gArticle.FindBy(x => x.IdArticulo == id).FirstOrDefault();
            var model = AutoMapper.Mapper.Map<Articulos, mArticle>(element);

            ViewBag.Estado = new SelectList(_gStatus.GetAll().ToList(), "Id", "Nombre");
            ViewBag.Tipo = new SelectList(_gArticleType.GetAll().ToList(), "Id", "Nombre");
            ViewBag.IVA = new SelectList(_gIVA.GetAll().ToList(), "Id", "Valor");

            return View(model);
        }





        [HttpPost]
        public ActionResult Edit(Articulos element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var model = AutoMapper.Mapper.Map<Articulos, mArticle>(element);
                    ViewBag.Estado = new SelectList(_gStatus.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.Tipo = new SelectList(_gArticleType.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.IVA = new SelectList(_gIVA.GetAll().ToList(), "Id", "Valor");

                    return View(model);
                }

                _gArticle.Edit(element);
                _gArticle.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el articulo." + ex);
            }

            return RedirectToAction("Index");
        }





        public ActionResult DeleteConfirmed(int id)
        {
            var element = _gArticle.FindBy(x => x.IdArticulo == id).FirstOrDefault();
            var model = AutoMapper.Mapper.Map<Articulos, mArticle>(element);

            return View(model);
        }



        [HttpPost]
        public ActionResult Delete(Articulos element)
        {
            try
            {
                _gArticle.Delete(element);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar el articulo." + ex);
            }

            return RedirectToAction("Index");
        }
    }
}
