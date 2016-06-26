using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.ComponentModel.DataAnnotations;


namespace Domain.Models.PedidoProveedor
{
    public class mPedidoProveedor
    {

        #region atributos

        [Display(Name = "Pedido")]
        public int Num_ped { get; set; }

        [Display(Name = "Proveedr")]
        public int idProv { get; set; }


        [Display(Name = "Tipo")]
        public int Tipo { get; set; }


        [Display(Name = "Estado")]
        public int Estado { get; set; }


        [Display(Name = "Pago")]
        public int Forma_pago { get; set; }


        [Display(Name = "Fecha")]
        public System.DateTime Fecha_A { get; set; }


        [Display(Name = "Total")]
        public double Total { get; set; }


        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }


        #endregion



        #region Constructores

        public mPedidoProveedor() { }


        public mPedidoProveedor(Pedido_p pedidoP)
        {
            Num_ped = pedidoP.Num_ped;
            idProv = pedidoP.idProv;
            Tipo = pedidoP.Tipo;
            Estado = pedidoP.Estado;
            Forma_pago = pedidoP.Forma_pago;
            Fecha_A = pedidoP.Fecha_A;
            Total = pedidoP.Total;
            Observaciones = pedidoP.Observaciones;
        }



        #endregion

    }
}
