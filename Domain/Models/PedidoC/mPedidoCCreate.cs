using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repository;
using System.Web.Mvc;
using Domain.Connection;

namespace Domain.Models.PedidoC
{
    public class mPedidoCCreate : mPedidoC
    {

        #region Atributos
        private ConnectionDB conn;

        public SelectList Clientes { get; set; }
        public SelectList Estados { get; set; }
        public SelectList FormasPago { get; set; }


        #endregion



        #region Constructres

        public mPedidoCCreate()
        {
            conn = new ConnectionDB();
            Clientes = new SelectList(conn.DB.Clientes, "IdCliente", "Razon_Social");
            Estados = new SelectList(conn.DB.EstadosPedido , "idEstados" , "Nombre");
            FormasPago = new SelectList(conn.DB.FormaPago , "IdPago" , "Nombre");

        }


        public mPedidoCCreate(Pedido_c pedidoC)
        : base(pedidoC)
        {
            conn = new ConnectionDB();
            Clientes = new SelectList(conn.DB.Clientes, "IdCliente", "Razon_Social");
            Estados = new SelectList(conn.DB.EstadosPedido, "idEstados", "Nombre");
            FormasPago = new SelectList(conn.DB.FormaPago, "IdPago", "Nombre");

        }


        #endregion


    }
}
