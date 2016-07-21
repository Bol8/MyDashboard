using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repository;
using Domain.Models.Articulo;

namespace Domain.Models.AlmacenProducto
{
    public class mAlmacenProducto
    {
        [Display(Name = "Almacén")]
        public int Almacen { get; set; }


        [Display(Name = "Articulo")]
        public int Articulo { get; set; }


        [Display(Name = "Stock")]
        public int Stock { get; set; }



        [Display(Name = "Lote")]
        public string Lote { get; set; }

        //[Display(Name = "Stock min.")]
        //public int StockMin { get; set; }


        //[Display(Name = "Stock max.")]
        //public int StockMax { get; set; }



        public virtual mArticle Article { get; set; }


    }
}
