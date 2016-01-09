using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Repository.Metadata
{
    public class PedidoCMetadata
    {


        [Display(Name = "Pedido")]
        public int Num_ped { get; set; }



        [Display(Name = "Cliente")]
        public int idCliente { get; set; }




        [Display(Name = "Destino")]
        [StringLength(50, ErrorMessage = "Max. {1} caracteres")]
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
        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }


    }
}
