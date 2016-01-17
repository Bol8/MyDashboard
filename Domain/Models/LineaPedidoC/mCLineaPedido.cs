using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Domain.Models.LineaPedidoC
{
    public class mCLineaPedido
    {

        private Entities db;


        [Display(Name = "Número Pedido")]
        [Required(ErrorMessage ="Campo requerido")]
        public int Num_ped { get; set; }

        [Display(Name = "Linea")]
        public int Linea { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Campo requerido")]
        [Range(1,99999,ErrorMessage ="Valores entre 1 y 99999")]
        public int Cantidad { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }


        [Display(Name = "Articulo")]
        [Required(ErrorMessage = "Campo requerido")]
        public int IdArticulo { get; set; }

        [Display(Name = "Unidades")]
        public int Unidades { get; set; }

       
        public SelectList Articulos { get; set; }


        public mCLineaPedido(int numPed)
        {
            db = new Entities();
            var articulos = getNameArticle();

            Articulos = new SelectList(articulos, "idArt", "Nombre");
            this.Num_ped = numPed;
            
        }

        public mCLineaPedido(Linea_pedido_c lpedido)
        {
            db = new Entities();
            var articulos = getNameArticle();

            Articulos = new SelectList(articulos, "idArt", "Nombre");
            this.Num_ped = lpedido.Num_ped;
            this.IdArticulo = lpedido.IdArticulo;
            this.Cantidad = lpedido.Cantidad;
            
        }




        private dynamic getNameArticle()
        {
          
            var st = db.Articulos.Select(
               s => new
               {
                   idArt = s.IdArticulo,
                   Nombre = s.Nombre + "   " + s.Peso + "gr."

               });

            return st;
        }
    }
}
