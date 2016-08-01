using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Models.AlmacenProducto
{
    public class mStoreArticleCreate
    {
        //[Display(Name = "ID")]
        //public int IdArticulo { get; set; }

        [Display(Name = "Lote")]
        [StringLength(15, ErrorMessage = "Max. {1} caracteres")]
        public string Lote { get; set; }
        
        [Display(Name = "Almacén")]
        public int Almacen { get; set; }

        [Display(Name = "Articulo")]
        public int Articulo { get; set; }

        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Display(Name = "Fecha Caducidad")]
        public DateTime FechaCaducidad { get; set; }

        [Display(Name = "Fecha Fabricación")]
        public DateTime FechaFabricacion { get; set; }

        [Display(Name = "Fecha Envasado")]
        public DateTime FechaEnvasado { get; set; }

        public SelectList Articles { get; set; }
      
     
        public mStoreArticleCreate() { }

        public mStoreArticleCreate(int idStore)
        {
            this.Almacen = idStore;
            this.FechaCaducidad = DateTime.Now;
            this.FechaEnvasado = DateTime.Now;
            this.FechaFabricacion = DateTime.Now;
        }

     



    }
}
