//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Almacen_MateriaPrima
    {
        public int Id { get; set; }
        public System.DateTime FechaRecogida { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public string CodigoInterno { get; set; }
        public Nullable<int> IdAlbaran { get; set; }
        public string Ubicacion { get; set; }
        public string Lote { get; set; }
    
        public virtual MateriaPrima MateriaPrima { get; set; }
        public virtual Pedido_p Pedido_p { get; set; }
    }
}