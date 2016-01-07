using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Repository.Metadata
{
    public class ProductMetadata
    {
        [Display(Name = "ID")]
        public int IdArticulo { get; set; }


        [Display(Name = "Código")]
        [StringLength(50, ErrorMessage = "Max. {1} caracteres")]
        public string Codigo { get; set; }



        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50, ErrorMessage = "Max. {1} caracteres")]
        public string Nombre { get; set; }


        [Display(Name = "Peso(gr.)")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Peso incorrecto")]
        public Nullable<double> Peso { get; set; }



        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Tipo { get; set; }



        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Estado { get; set; }



        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Precio incorrecto")]
        public double Precio { get; set; }



        [Display(Name = "IVA")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int IVA { get; set; }



        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }



        [Display(Name = "Origen")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Origen { get; set; }




        public string Imagen { get; set; }



    }
}
