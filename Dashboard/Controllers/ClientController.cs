using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;
using Domain.Models.Cliente;
using AutoMapper;
using Domain.Interfaces;
using Elmah;
using Domain.Others;
using Domain.Connection;


namespace Dashboard.Controllers
{

    public class ClientController : Controller
    {
        private IGenericRepository<Clientes> _gClient;
        private IGenericRepository<Estados> _gStatus;

        #region Constructors

        public ClientController(IGenericRepository<Clientes> repo, IGenericRepository<Estados> st)
        {
            this._gClient = repo;
            this._gStatus = st;
        }
        #endregion


        [HttpGet]
        public ActionResult Index()
        {
            var list = _gClient.GetAll().ToList();
            var modelList = Mapper.Map<IEnumerable<Clientes>, IEnumerable<mCliente>>(list).ToList();

            //Column<mCliente> column = new Column<mCliente>("Agentes", "Agente");
            //column.AddRange(modelList);

            //var a = column;

            return View(modelList);
        }



        [HttpGet]
        public ActionResult Create()
        {
            var model = new mClientCreate();

            return View(model);
        }



        [HttpPost]
        public ActionResult Create(Clientes element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var model = new mClientCreate(element);

                    return View(model);
                }

                _gClient.Add(element);
                _gClient.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el cliente. " + ex);
            }

            return RedirectToAction("Index");

        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var element = _gClient.FindBy(x=> x.IdCliente == id).FirstOrDefault();
            var model = new mClientCreate(element);

            ViewBag.Estado = new SelectList(_gStatus.GetAll().ToList(), "IdEstado", "Nombre");
            
            return View(model);
        }





        [HttpPost]
        public ActionResult Edit(Clientes client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var model = AutoMapper.Mapper.Map<Clientes, mCliente>(client);
                    ViewBag.Estado = new SelectList(_gStatus.GetAll().ToList(), "IdEstado", "Nombre");

                    return View(model);
                }

                _gClient.Edit(client);
                _gClient.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el cliente." + ex);
            }

            return RedirectToAction("Index");
        }





        public ActionResult DeleteConfirmed(int id)
        {
            var element = _gClient.FindBy(x=> x.IdCliente == id).FirstOrDefault();

            return View(element);
        }

        

        [HttpPost]
        public ActionResult Delete(Clientes element)
        {
            try
            {
                _gClient.Delete(element);
            }
            catch (Exception ex )
            {
                throw new Exception("Error al intentar eliminar el cliente." + ex);
            }

            return RedirectToAction("Index");
        }
    }
}
