﻿using System;
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
        [Display(Name = "ID")]
        public int IdArticulo { get; set; }


        [Display(Name = "Código")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string Codigo { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string Nombre { get; set; }


        [Display(Name = "Peso")]
        public Nullable<decimal> Peso { get; set; }


        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Tipo { get; set; }


        [Display(Name = "Tipo")]
        public string sTipo { get; set; }


        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Estado { get; set; }


        [Display(Name = "Estado")]
        public string sEstado { get; set; }


        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public decimal Precio { get; set; }



        [Display(Name = "IVA")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int IVA { get; set; }


        [Display(Name = "IVA")]
        public string sIVA { get; set; }


        [Display(Name = "Descripción")]
        [StringLength(1000, ErrorMessage = "Max. {1} caracteres")]
        public string Descripcion { get; set; }


        public string Imagen { get; set; }

        

        [Display(Name = "Almacén")]
        public int Almacen { get; set; }


        [Display(Name = "Articulo")]
        public int Articulo { get; set; }


        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Display(Name = "Stock disponible")]
        public int StockDisponible { get; set; }


        [Display(Name = "Stock min.")]
        public int StockMin { get; set; }


        [Display(Name = "Stock max.")]
        public int StockMax { get; set; }


        public SelectList Estados { get; set; }
        public SelectList Tipos { get; set; }
        public SelectList Ivas { get; set; }


        #region Constructores

        public mStoreArticleCreate() { }

        public mStoreArticleCreate(int idStore)
        {
            this.Almacen = idStore;
        }

        #endregion



    }
}
