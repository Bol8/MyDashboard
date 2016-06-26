using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.ComponentModel.DataAnnotations;
using Domain.Connection;
using System.Web.Mvc;

namespace Domain.Models.PedidoProveedor
{
    public class mPedidoProvCreate
    {
        #region Atributos

        private ConnectionDB conn;


        public SelectList Proveedores { get; set; }

        public SelectList Estados { get; set; }

        public SelectList Tipos { get; set; }

        public SelectList FormasDePago { get; set; }



        #endregion


        #region Constructores

        public mPedidoProvCreate()
        {
            conn = new ConnectionDB();

            Proveedores = new SelectList(conn.DB.Proveedores, "", "");
            Estados = new SelectList(conn.DB.Estados);
          //  Tipos = new SelectList(conn.DB.T);

        }


        public mPedidoProvCreate(Pedido_p pedidoP)
        {

        }


        #endregion


    }
}
