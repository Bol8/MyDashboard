using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Domain.Models.PedidoC
{
    public class mPedidoC
    {

        #region Atributos


        [Display(Name = "Pedido")]
        public int Num_ped { get; set; }


        [Display(Name = "Cliente")]
        public int idCliente { get; set; }


        [Display(Name = "Destino")]
        public string Destino { get; set; }


        [Display(Name = "Estado")]
        public int Estado { get; set; }


        [Display(Name = "Pago")]
        public int Forma_pago { get; set; }


        [Display(Name = "Fecha")]
        public System.DateTime Fecha_A { get; set; }


        [Display(Name = "Total")]
        public float Total { get; set; }


        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }


        #endregion


        #region Constructores

       public  mPedidoC() { }


       public  mPedidoC(Pedido_c pedidoC)
        {
            Num_ped = pedidoC.Num_ped;
            idCliente = pedidoC.idCliente;
            Destino = pedidoC.Destino;
            Estado = pedidoC.Estado;
            Forma_pago = pedidoC.Forma_pago;
            Fecha_A = pedidoC.Fecha_A;
            Total = pedidoC.Total;
            Observaciones = pedidoC.Observaciones;
        }


        #endregion



    }
}
