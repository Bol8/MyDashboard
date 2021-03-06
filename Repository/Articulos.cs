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
    
    public partial class Articulos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulos()
        {
            this.Almacen_Productos = new HashSet<Almacen_Productos>();
            this.Linea_pedido_c = new HashSet<Linea_pedido_c>();
            this.Linea_pedido_p = new HashSet<Linea_pedido_p>();
        }
    
        public int IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Peso { get; set; }
        public int Tipo { get; set; }
        public int Estado { get; set; }
        public decimal Precio { get; set; }
        public int IVA { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Almacen_Productos> Almacen_Productos { get; set; }
        public virtual Estados Estados { get; set; }
        public virtual Iva Iva1 { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Linea_pedido_c> Linea_pedido_c { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Linea_pedido_p> Linea_pedido_p { get; set; }
    }
}
