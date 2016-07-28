using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.ProductProvider
{
    public class mProductProvider
    {

        [Display(Name ="Código")]
        public int Id { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string Nombre { get; set; }


        [Display(Name = "Proveedor")]
        public int IdProveedor { get; set; }
        
    }
}
