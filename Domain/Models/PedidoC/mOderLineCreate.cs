using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Models.PedidoC
{
    public class mOderLineCreate
    {

        [Display(Name ="Pedido")]
        public int Num_ped { get; set; }




        [Display(Name = "Linea")]
        public int Linea { get; set; }




        [Display(Name = "Cantidad")]
        [Range(1,9999,ErrorMessage ="Números entre {1} y {2}")]
        public int Cantidad { get; set; }




        [Display(Name = "Total")]
        public double Total { get; set; }




        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
        


        [Display(Name = "Articulo")]
        public int IdArticulo { get; set; }



        public SelectList ArticleList { get; set; }
        
    }
}
