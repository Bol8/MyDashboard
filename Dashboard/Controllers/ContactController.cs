using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;
using Domain.Models.Contact;
using Dashboard.ModelBinding;
using Dashboard.Models;
using Domain.Interfaces;
using AutoMapper;

namespace Dashboard.Controllers
{
    public class ContactController : Controller
    {
        IGenericRepository<Contactos> _gContact;


        #region Constructores
        
        public ContactController(IGenericRepository<Contactos> gContact)
        {
            _gContact = gContact;
        }

        #endregion


        [HttpGet]
        public ActionResult Index()
        {
            var list = _gContact.GetAll().ToList();
            var modelList = Mapper.Map<IEnumerable<Contactos>, IEnumerable<mContact>>(list).ToList();
            
            return View(modelList);
        }



        [HttpGet]
        public ActionResult Create()
        {
            var model = new mContact();

            return View(model);
        }



        [HttpPost]
        public ActionResult Create(Contactos element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var model = Mapper.Map<Contactos, mContact>(element);

                    return View(model);
                }

                _gContact.Add(element);
                _gContact.Save();
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
            var element = _gContact.FindBy(x => x.IdContacto == id).FirstOrDefault();
            var model = Mapper.Map<Contactos, mContact>(element);
            
            return View(model);
        }





        [HttpPost]
        public ActionResult Edit(Contactos element)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var model = AutoMapper.Mapper.Map<Contactos, mContact>(element);
                    return View(model);
                }

                _gContact.Edit(element);
                _gContact.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar modificar el contacto." + ex);
            }

            return RedirectToAction("Index");
        }





        public ActionResult DeleteConfirmed(int id)
        {
            var element = _gContact.FindBy(x => x.IdContacto == id).FirstOrDefault();
            var model = AutoMapper.Mapper.Map<Contactos, mContact>(element);

            return View(model);
        }



        [HttpPost]
        public ActionResult Delete(Contactos element)
        {
            try
            {
                _gContact.Delete(element);
                _gContact.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar el contacto." + ex);
            }

            return RedirectToAction("Index");
        }
    }
}
