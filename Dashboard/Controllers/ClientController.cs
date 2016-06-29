using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;
using Domain.Models.Cliente;
using AutoMapper;

namespace Dashboard.Controllers
{
    public class ClientController : Controller
    {
        private ControlClient client;
        private gStatus gStatus;

        #region Constructors

        public ClientController()
        {
            gStatus = new gStatus();
        }

        #endregion


        [HttpGet]
        public ActionResult Index()
        {
            gClient _gClient = new gClient();
            var clients = _gClient.GetAll().ToList();
            var modelList = Mapper.Map<IEnumerable<Clientes>, IEnumerable<mCliente>>(clients).ToList();

            return View(modelList);
        }

        

        [HttpGet]
        public ActionResult Create()
        {
            gClient _gClient = new gClient();
            var model = _gClient.GetAll(); ;

            return View(model);
        }



        [HttpPost]
        public ActionResult Create(Clientes client)
        {

            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");

            //    return View(client);
            //}

            //if (!ControlClient.save(client)) throw new Exception("Error al intentar crear el cliente");

            return RedirectToAction("Index");

        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            gClient _gClient = new gClient();
            var client = _gClient.getSingle(id);
            var model = AutoMapper.Mapper.Map<Clientes, mCliente>(client);

            // client = new ControlClient(id);
           // var model = ControlClient.getElement(id);
            ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");

            return View(model);
        }





        [HttpPost]
        public ActionResult Edit(Clientes cliente)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.Estado = new SelectList(gStatus.getElements(), "IdEstado", "Nombre");

            //    return View(cliente);
            //}

            //if (!client.edit(cliente)) throw new Exception("Error al intentar modificar el cliente");

            return RedirectToAction("Index");
        }





        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var cliente = client.getElementById(id);

        //    return View(cliente);
        //}





        //[HttpPost]
        //public ActionResult Delete(Clientes cliente)
        //{
        //    if (!client.delete(cliente.IdCliente)) throw new Exception("Error al intentar eliminar el cliente");

        //    return RedirectToAction("Index");
        //}
    }
}
