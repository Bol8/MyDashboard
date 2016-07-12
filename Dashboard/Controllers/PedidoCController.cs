using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models.PedidoC;
using Domain.Interfaces;
using Repository;
using AutoMapper;



namespace Dashboard.Controllers
{
    public class PedidoCController : Controller
    {
        #region Parametros

        private IGenericRepository<Pedido_c> _gPedidoC;
        private IGenericRepository<Clientes> _gClient;
        private IGenericRepository<FormaPago> _gPaymentType;
        private IGenericRepository<EstadosPedido> _gOrderStatus;

        #endregion


        #region Constructores

        public PedidoCController(IGenericRepository<Pedido_c> gPedidoC,
                                 IGenericRepository<EstadosPedido> gOrderStatus,
                                 IGenericRepository<FormaPago> gPaymentType,
                                 IGenericRepository<Clientes> gClient)
        {
            this._gPedidoC = gPedidoC;
            this._gOrderStatus = gOrderStatus;
            this._gPaymentType = gPaymentType;
            this._gClient = gClient;
        }

        #endregion


        [HttpGet]
        public ActionResult Index()
        {
            var list = _gPedidoC.GetAll().ToList();
            var modelList = Mapper.Map<IEnumerable<Pedido_c>, IEnumerable<mPedidoC>>(list).ToList();

            return View(modelList);
        }



        [HttpGet]
        public ActionResult Create()
        {
            var model = new mPedidoCCreate();
            model.FormasPago = new SelectList(_gPaymentType.GetAll().ToList(), "IdPago", "Nombre");
            model.ClientList = new SelectList(_gClient.GetAll().ToList(), "IdCliente", "Razon_Social");
            model.Estados = new SelectList(_gOrderStatus.GetAll().ToList(), "idEstados", "Nombre");
            
            return View(model);
        }



        [HttpPost]
        public ActionResult Create(Pedido_c element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var model = Mapper.Map<Pedido_c, mPedidoCCreate>(element);
                    model.FormasPago = new SelectList(_gPaymentType.GetAll().ToList(), "IdPago", "Nombre");
                    model.ClientList = new SelectList(_gClient.GetAll().ToList(), "IdCliente", "Razon_Social");
                    model.Estados = new SelectList(_gOrderStatus.GetAll().ToList(), "idEstados", "Nombre");

                    return View(model);
                }

                _gPedidoC.Add(element);
                _gPedidoC.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el contacto. " + ex);
            }

            return RedirectToAction("Index");

        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var element = _gPedidoC.FindBy(x => x.Num_ped == id).FirstOrDefault();

            var model = Mapper.Map<Pedido_c, mPedidoCCreate>(element);
            model.FormasPago = new SelectList(_gPaymentType.GetAll().ToList(), "IdPago", "Nombre");
            model.ClientList = new SelectList(_gClient.GetAll().ToList(), "IdCliente", "Razon_Social");
            model.Estados = new SelectList(_gOrderStatus.GetAll().ToList(), "idEstados", "Nombre");

            return View(model);
        }





        [HttpPost]
        public ActionResult Edit(Pedido_c element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var model = Mapper.Map<Pedido_c, mPedidoCCreate>(element);
                    model.FormasPago = new SelectList(_gPaymentType.GetAll().ToList(), "IdPago", "Nombre");
                    model.ClientList = new SelectList(_gClient.GetAll().ToList(), "IdCliente", "Razon_Social");
                    model.Estados = new SelectList(_gOrderStatus.GetAll().ToList(), "idEstados", "Nombre");

                    return View(model);
                }

                _gPedidoC.Edit(element);
                _gPedidoC.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el contacto." + ex);
            }

            return RedirectToAction("Index");
        }





        public ActionResult DeleteConfirmed(int id)
        {
            var element = _gPedidoC.FindBy(x => x.Num_ped == id).FirstOrDefault();
            var model = AutoMapper.Mapper.Map<Pedido_c, mPedidoC>(element);

            return View(model);
        }



        [HttpPost]
        public ActionResult Delete(Pedido_c element)
        {
            try
            {
                _gPedidoC.Delete(element);
                _gPedidoC.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar el contacto." + ex);
            }

            return RedirectToAction("Index");
        }
    }
}
