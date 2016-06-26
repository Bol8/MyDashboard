﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.ComponentModel.DataAnnotations;
using Domain.Connection;
using System.Web.Mvc;

namespace Domain.Models.Cliente
{
    public class mClientCreate : mCliente
    {
        #region Atributos

        private ConnectionDB conn;
        public SelectList Estados { get; set; }

        #endregion


        #region Constructores

        public mClientCreate()
        {
            conn = new ConnectionDB();
            Estados = new SelectList(conn.DB.Estados, "IdEstado", "Nombre");
        }

        public mClientCreate(Clientes client)
            : base(client)
        {
            conn = new ConnectionDB();
            Estados = new SelectList(conn.DB.Estados, "IdEstado", "Nombre");
        }

        #endregion



    }
}