using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models.PedidoC;
using Domain.Interfaces;
using Repository;
using AutoMapper;
using Domain.DefaultValues;

namespace Dashboard.Controllers
{
    public class PedidoCController : Controller
    {
        #region Parametros

        private IGenericRepository<Pedido_c> _gPedidoC;
        private IGenericRepository<Clientes> _gClient;
        private IGenericRepository<FormaPago> _gPaymentType;
        private IGenericRepository<EstadosPedido> _gOrderStatus;
        private IGenericRepository<Almacenes> _gStore;

        #endregion


        #region Constructores

        public PedidoCController(IGenericRepository<Pedido_c> gPedidoC,
                                 IGenericRepository<EstadosPedido> gOrderStatus,
                                 IGenericRepository<FormaPago> gPaymentType,
                                 IGenericRepository<Clientes> gClient,
                                 IGenericRepository<Almacenes> gStore)
        {
            this._gPedidoC = gPedidoC;
            this._gOrderStatus = gOrderStatus;
            this._gPaymentType = gPaymentType;
            this._gClient = gClient;
            this._gStore = gStore;
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



        #region lineas pedido


        public ActionResult OpenOrder(int id)
        {
            var element = _gPedidoC.FindBy(x => x.Num_ped == id).FirstOrDefault();
            var model = Mapper.Map<Pedido_c, mPedidoC>(element);
            return View(model);
        }


        public ActionResult OrderLineCreate(int id)
        {
            var store = _gStore.FindBy(x => x.Id == DefaultStoreValues.DefaultStore).FirstOrDefault();
            //ViewBag.idOrder = id;

            var model = new mOderLineCreate();
            model.Num_ped = id;

            model.ArticleList = new SelectList(store.Almacen_Productos.Select(x => x.Articulos).ToList(), "IdArticulo", "Nombre");
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult OrderLineCreate(Linea_pedido_c element)
        {
            var order = _gPedidoC.FindBy(x => x.Num_ped == element.Num_ped).FirstOrDefault();
            order.Linea_pedido_c.Add(element);

            _gPedidoC.Save();

            var modelList = Mapper.Map<IEnumerable<Linea_pedido_c>, IEnumerable<mOrderLine>>(order.Linea_pedido_c.ToList()).ToList();
            if (Request.IsAjaxRequest()) return PartialView("OrderLines",modelList);


            return RedirectToAction("OpenOrder", new { id = element.Num_ped });
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult OrderLines(int id)
        {
            var order = _gPedidoC.FindBy(x => x.Num_ped == id).FirstOrDefault();
            var list = order.Linea_pedido_c.ToList();

            var modelList = Mapper.Map<IEnumerable<Linea_pedido_c>, IEnumerable<mOrderLine>>(list).ToList();
          
            return PartialView(modelList);
        }





        #endregion
    }
}
