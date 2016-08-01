using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.StoreProductProvider
{
    public class MStoreProductProvider
    {
       
        [Display(Name = "ID")]
        public int Id { get; set; }



        [Display(Name = "Fecha recogida")]
        public DateTime FechaRecogida { get; set; }


        [Display(Name = "Producto")]
        public int IdProducto { get; set; }


        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }


        [Display(Name = "Unidad")]
        public string Unidad { get; set; }


        [Display(Name = "Lote interno")]
        public string CodigoInterno { get; set; }


        [Display(Name = "Albarán")]
        public int? IdAlbaran { get; set; }


        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }


        [Display(Name = "Lote")]
        public string Lote { get; set; }


        [Display(Name = "Producto")]
        public string NombreProducto { get; set; }


        [Display(Name = "Proveedor")]
        public string NombreProveedor { get; set; }


        //public MStoreProductProvider(string nombreProveedor, string nombreProducto)
        //{
        //    NombreProveedor = nombreProveedor;
        //    NombreProducto = nombreProducto;
        //}

        //protected MStoreProductProvider()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
