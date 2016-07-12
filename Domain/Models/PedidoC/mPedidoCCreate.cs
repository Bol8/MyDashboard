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
    public class mPedidoCCreate
    {

        #region Atributos

        [Display(Name = "Pedido")]
        public int Num_ped { get; set; }


        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int idCliente { get; set; }

        [Display(Name = "Cliente")]
        public string clienteNombre { get; set; }


        [Display(Name = "Direccion")]
        public string Direccion { get; set; }


        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Estado { get; set; }


        [Display(Name = "Estado")]
        public string sEstado { get; set; }


        [Display(Name = "Pago")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Forma_pago { get; set; }

        [Display(Name = "Pago")]
        public string sForma_pago { get; set; }


        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public System.DateTime Fecha_A { get; set; }


        [Display(Name = "Peso")]
        public decimal? Peso { get; set; }


        [Display(Name = "Importe")]
        public float Importe { get; set; }


        [Display(Name = "Observaciones")]
        [StringLength(1000, ErrorMessage = "Max. {1} caracteres")]
        public string Observaciones { get; set; }


        public SelectList Clientes { get; set; }
        public SelectList Estados { get; set; }
        public SelectList FormasPago { get; set; }

        #endregion




        #region Constructres

        public mPedidoCCreate()
        {
            Fecha_A = DateTime.Now;
        }


        //public mPedidoCCreate(Pedido_c pedidoC)
        //: base(pedidoC)
        //{
        //    conn = new ConnectionDB();
        //    Clientes = new SelectList(conn.DB.Clientes, "IdCliente", "Razon_Social");
        //    Estados = new SelectList(conn.DB.EstadosPedido, "idEstados", "Nombre");
        //    FormasPago = new SelectList(conn.DB.FormaPago, "IdPago", "Nombre");

        //}


        #endregion


    }
}
