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


        [Display(Name = "Direccion")]
        public string Direccion { get; set; }


        [Display(Name = "Estado")]
        public int Estado { get; set; }


        [Display(Name = "Pago")]
        public int Forma_pago { get; set; }


        [Display(Name = "Fecha")]
        public System.DateTime Fecha_A { get; set; }


        [Display(Name = "Peso")]
        public decimal? Peso { get; set; }


        [Display(Name = "Importe")]
        public float Importe { get; set; }


        [Display(Name = "Observaciones")]
        [StringLength(1000, ErrorMessage = "Max. {1} caracteres")]
        public string Observaciones { get; set; }


        #endregion


        #region Constructores

       public  mPedidoC() { }


       public  mPedidoC(Pedido_c pedidoC)
        {
            Num_ped = pedidoC.Num_ped;
            idCliente = pedidoC.idCliente;
            Direccion = pedidoC.Direccion;
            Estado = pedidoC.Estado;
            Forma_pago = pedidoC.Forma_pago;
            Fecha_A = pedidoC.Fecha_A;
            Importe = pedidoC.Importe;
            Peso = pedidoC.Peso;
            Observaciones = pedidoC.Observaciones;
        }


        #endregion



    }
}
