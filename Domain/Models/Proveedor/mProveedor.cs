using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Domain.Models.Proveedor
{
    public class mProveedor
    {
        #region Atributos

        [Display(Name = "Código")]
        public int IdProveedor { get; set; }


        [Display(Name = "Nombre fiscal")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string RazonSocial { get; set; }

        [Display(Name = "Nº R.Sanitario")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string R_Sanitario { get; set; }


        [Display(Name = "Nombre comercial")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string NombreComercial { get; set; }


        [Display(Name = "NIF")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^(([A-Z]{1})([-]?)(\d{8}))|((\d{8})([-]?)([A-Z]{1}))|(([A-Z]{1})([-]?)(\d{7})([A-Z]{1}))$", ErrorMessage = "NIF incorrecto")]
        public string NIF { get; set; }


        [Display(Name = "Domicilio")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string Domicilio { get; set; }


        [Display(Name = "CP")]
        [RegularExpression(@"^(([0-9]{5}))$", ErrorMessage = "CP incorrecto")]
        public string CP { get; set; }


        [Display(Name = "Población")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string Poblacion { get; set; }



        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string Provincia { get; set; }


        [Display(Name = "País")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string Pais { get; set; }


        [Display(Name = "Fecha alta")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public System.DateTime Fecha_A { get; set; }



        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Estado { get; set; }


        [Display(Name = "Estado")]
        public string sEstado { get; set; }


        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Número incorrecto")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Número incorrecto")]
        public string Telefono { get; set; }


        [Display(Name = "Móvil")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Número incorrecto")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Número incorrecto")]
        public string Movil { get; set; }


        [Display(Name = "Mail")]
        [EmailAddress(ErrorMessage = "Mail incorrecto")]
        [StringLength(250, ErrorMessage = "Max. {1} caracteres")]
        public string Mail { get; set; }


        [Display(Name = "Nota")]
        [DataType(DataType.MultilineText)]
        public string Nota { get; set; }


        public string Imagen { get; set; }

        #endregion
        

        #region Constructores

        public mProveedor() { }


        public mProveedor(Proveedores proveedor)
        {
            IdProveedor = proveedor.IdProveedor;
            RazonSocial = proveedor.RazonSocial;
            NombreComercial = proveedor.NombreComercial;
            NIF = proveedor.NIF;
            Domicilio = proveedor.Domicilio;
            CP = proveedor.CP;
            Poblacion = proveedor.Poblacion;
            Provincia = proveedor.Provincia;
            Pais = proveedor.Pais;
            Fecha_A = proveedor.Fecha_A;
            Estado = proveedor.Estado;
            sEstado = proveedor.Estados.Nombre;
            Telefono = proveedor.Telefono;
            Mail = proveedor.Mail;
            Nota = proveedor.Nota;
        }


        #endregion


    }
}
