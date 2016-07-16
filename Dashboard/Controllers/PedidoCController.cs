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
using Domain.Tools;

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
        private IGenericRepository<Linea_pedido_c> _gOrderLine;

        #endregion


        #region Constructores

        public PedidoCController(IGenericRepository<Pedido_c> gPedidoC,
                                 IGenericRepository<EstadosPedido> gOrderStatus,
                                 IGenericRepository<FormaPago> gPaymentType,
                                 IGenericRepository<Clientes> gClient,
                                 IGenericRepository<Almacenes> gStore,
                                 IGenericRepository<Linea_pedido_c> gOrderLine)
        {
            this._gPedidoC = gPedidoC;
            this._gOrderStatus = gOrderStatus;
            this._gPaymentType = gPaymentType;
            this._gClient = gClient;
            this._gStore = gStore;
            this._gOrderLine = gOrderLine;
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
            var store = _gStore.FindBy(x => x.Id == DefaultStoreValues.DefaultStore).FirstOrDefault();
            var article = store.Almacen_Productos.Where(x => x.Articulo == element.IdArticulo).FirstOrDefault();

            if(article.Stock >= element.Cantidad)
            {
                var order = _gPedidoC.FindBy(x => x.Num_ped == element.Num_ped).FirstOrDefault();
                article.Stock -= element.Cantidad;

                order.Peso += element.Cantidad * article.Articulos.Peso;
                order.Importe += (float) (element.Cantidad * article.Articulos.Precio);

                element.Total = (double)(element.Cantidad * article.Articulos.Precio);

                _gOrderLine.Add(element);

                _gOrderLine.Save();
                _gPedidoC.Save();
                _gStore.Save();

               
                TempData["MessageSucces"] = "Completado correctamente";
                TempData["Importe"] = order.Importe.ToString();
                TempData["Peso"] = (order.Peso/1000).ToString();

                var updateOrder = _gPedidoC.FindBy(x => x.Num_ped == element.Num_ped).FirstOrDefault();
                var modelList = Mapper.Map<IEnumerable<Linea_pedido_c>, IEnumerable<mOrderLine>>(updateOrder.Linea_pedido_c.ToList()).ToList();
                if (Request.IsAjaxRequest()) return PartialView("OrderLines", modelList);

            }else
            {
                TempData["MessageWarning"] = "No hay unidades suficientes";
            }

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


        [HttpPost]
        public ActionResult DeleteOrderLine(int idOrder , int idOrderLine)
        {
            try
            {
                var store = _gStore.FindBy(x => x.Id == DefaultStoreValues.DefaultStore).FirstOrDefault();
                var order = _gPedidoC.FindBy(x => x.Num_ped == idOrder).FirstOrDefault();
                var orderLine = order.Linea_pedido_c.Where(x => x.Linea == idOrderLine).FirstOrDefault();
                var article = store.Almacen_Productos.Where(x => x.Articulo == orderLine.Articulos.IdArticulo).FirstOrDefault();

                order.Importe -= (float)(orderLine.Cantidad * orderLine.Articulos.Precio);
                order.Peso -= (orderLine.Cantidad * orderLine.Articulos.Peso);
                article.Stock += orderLine.Cantidad;
                
                order.Linea_pedido_c.Remove(orderLine);

                _gPedidoC.Save();
                _gStore.Save();

                TempData["MessageSucces"] = "Completado correctamente";
                TempData["Importe"] = order.Importe.ToString();
                TempData["Peso"] = (order.Peso / 1000).ToString();

                var modelList = Mapper.Map<IEnumerable<Linea_pedido_c>, IEnumerable<mOrderLine>>(order.Linea_pedido_c.ToList()).ToList();

                return PartialView("OrderLines",modelList);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar una linea de pedido. " + ex);
            }

        }


        #endregion
    }
}
