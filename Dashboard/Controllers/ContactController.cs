﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Manage;
using Repository;
using Domain.Models.Contact;

namespace Dashboard.Controllers
{
    public class ContactController : Controller
    {

        private gContact gContact;

        #region Constructors

        public ContactController()
        {
            gContact = new gContact();
        }

        #endregion


        [HttpGet]
        public ActionResult Index()
        {
            var contactList = gContact.getElements();
            return View(contactList);
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }



        [HttpGet]
        public ActionResult Create()
        {
            var model = new mContact();

            return View(model);
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(Contactos contact)
        {
            if (!ModelState.IsValid)
            {
                var model = new mContact(contact);
                return View(model);
            }

            if (!gContact.save(contact)) throw new Exception("Error al intentar crear un contacto");

            return RedirectToAction("Index");

        }


        public ActionResult Edit(int id)
        {
            var model = new mContact(gContact.getElementById(id));
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(Contactos contact)
        {
            if (!ModelState.IsValid) return View(contact);
            if (!gContact.edit(contact)) throw new Exception("Error al intentar modificar el contacto nº:"+contact.IdContacto );

            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult DeleteConfirmed(int id)
        {
            var contact = gContact.getElementById(id);

            return View(contact);
        }




        [HttpPost]
        public ActionResult Delete(Contactos contact)
        {
            if (!gContact.delete(contact.IdContacto)) throw new Exception("Error al intentar eliminar el contacto");

            return RedirectToAction("Index");

        }
    }
}
