using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.PedidoC
{
    public class mOrderLine
    {
        [Display(Name = "Pedido")]
        public int Num_ped { get; set; }



        [Display(Name = "Linea")]
        public int Linea { get; set; }


        [Display(Name = "Lote")]
        public string Lote { get; set; }


        [Display(Name = "Unidades")]
        public int Cantidad { get; set; }




        [Display(Name = "Total")]
        public double Total { get; set; }




        [Display(Name = "Precio")]
        public decimal Precio { get; set; }




        [Display(Name = "Peso")]
        public decimal Peso { get; set; }



        [Display(Name = "Total peso")]
        public decimal TotalPeso { get; set; }




        [Display(Name = "Articulo")]
        public int IdArticulo { get; set; }


        [Display(Name = "Articulo")]
        public string sArticulo { get; set; }
    }
}
