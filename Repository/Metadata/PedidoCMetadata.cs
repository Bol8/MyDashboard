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
        [Required(ErrorMessage = "Campo obligatorio")]
        public int idCliente { get; set; }




        [Display(Name = "Destino")]
        [StringLength(50, ErrorMessage = "Max. {1} caracteres")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Destino { get; set; }




        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Estado { get; set; }




        [Display(Name = "Pago")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Forma_pago { get; set; }




        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public System.DateTime Fecha_A { get; set; }




        [Display(Name = "Total")]
        public float Total { get; set; }



        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }


    }
}
