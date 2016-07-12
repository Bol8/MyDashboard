using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;
using Domain.Models.LineaPedidoC;

namespace Dashboard.Controllers
{
    public class LineaPedidoCController : Controller
    {
        //private gLineaPedidoC gLineaPedidoC;
        //private gProduct gProduct;

        //#region Constructors

        //public LineaPedidoCController()
        //{
        //    gLineaPedidoC = new gLineaPedidoC();
        //    gProduct = new gProduct();
        //}

        //#endregion


        ////[HttpGet]
        //public ActionResult Index(int numPed)
        //{
        //    var orderLines = gLineaPedidoC.getElementsById(numPed);

        //    return PartialView(orderLines);
        //}


        //// GET: LineaPedidoC/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}



        //[HttpGet]
        //public ActionResult Create(int NumPed)
        //{
        //    var model = new mCLineaPedido(NumPed);
            
        //    return View(model);
        //}





        //[HttpPost]
        //public ActionResult Create(Linea_pedido_c lpedido,int Unidades)
        //{
        //    if(lpedido.Cantidad > gProduct.count(lpedido.IdArticulo))
        //    {
        //        ModelState.AddModelError(String.Empty, "No hay unidades suficientes");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        var model = new mCLineaPedido(lpedido);
        //        model.Unidades = Unidades;
               
        //        return View(model);
        //    }

        //    lpedido.Linea = gLineaPedidoC.getNumLine(lpedido.Num_ped);
        //    if (!gLineaPedidoC.save(lpedido)) throw new Exception("Error al intentar guardar el pedido");

            
        //    return RedirectToAction("Create", new { numPed = lpedido.Num_ped});

        //}




        //// GET: LineaPedidoC/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}




        //// POST: LineaPedidoC/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}




        //// GET: LineaPedidoC/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}




        //// POST: LineaPedidoC/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}




        //#region Private methods

        //private dynamic getNameArticle()
        //{
        //    gProduct gProduct = new gProduct();

        //    var st = gProduct.getElements().Select(
        //       s => new
        //       {
        //           idArt = s.IdArticulo,
        //           Nombre = s.Nombre + "   " + s.Peso + "gr."

        //       });

        //    return st;
        //}


        //#endregion


    }
}
