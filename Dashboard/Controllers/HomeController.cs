using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Connection;
using Domain.Models;
using Repository;
using Domain.Interfaces;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository<Usuarios> _gUser;
        private IGenericRepository<Empresas> _gCompany;

        public HomeController(IGenericRepository<Usuarios> gUser, IGenericRepository<Empresas> gCompany)
        {
            this._gUser = gUser;
            this._gCompany = gCompany;
        }


        public ActionResult Index()
        {
            var company = _gCompany.FindBy(x => x.idUsuario == 1).FirstOrDefault();
            if (company == null) return View("NoCompany");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}