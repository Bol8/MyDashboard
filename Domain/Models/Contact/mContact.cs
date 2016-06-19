using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Domain.Connection;

namespace Domain.Models.Contact
{
    public class mContact
    {
        #region Atributos

        [Display(Name = "ID")]
        public int IdContacto { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50, ErrorMessage = "Max. {1} caracteres")]
        public string Nombre { get; set; }


        [Display(Name = "Origen")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50, ErrorMessage = "Max. {1} caracteres")]
        public string Origen { get; set; }


        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50, ErrorMessage = "Max. {1} caracteres")]
        public string Producto { get; set; }



        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Número incorrecto")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Número incorrecto")]
        public string Telefono { get; set; }


        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(50, ErrorMessage = "Max. {1} caracteres")]
        [EmailAddress(ErrorMessage = "Mail incorrecto")]
        public string Mail { get; set; }


        [Display(Name = "Nota")]
        [DataType(DataType.MultilineText)]
        public string Nota { get; set; }

        #endregion


        #region Constructores

        public mContact() { }


        public mContact(Repository.Contactos contact)
        {
            IdContacto = contact.IdContacto;
            Nombre = contact.Nombre;
            Origen = contact.Origen;
            Producto = contact.Producto;
            Telefono = contact.Telefono;
            Mail = contact.Mail;
            Nota = contact.Nota;
        }
       


        #endregion



    }
}
