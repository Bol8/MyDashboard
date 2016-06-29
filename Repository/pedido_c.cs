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
    
    public partial class Pedido_c
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido_c()
        {
            this.Facturas = new HashSet<Facturas>();
            this.Linea_pedido_c = new HashSet<Linea_pedido_c>();
        }
    
        public int Num_ped { get; set; }
        public int idCliente { get; set; }
        public string Destino { get; set; }
        public int Estado { get; set; }
        public int Forma_pago { get; set; }
        public System.DateTime Fecha_A { get; set; }
        public float Total { get; set; }
        public string Observaciones { get; set; }
    
        public virtual EstadosPedido EstadosPedido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facturas> Facturas { get; set; }
        public virtual FormaPago FormaPago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Linea_pedido_c> Linea_pedido_c { get; set; }
        public virtual Clientes Clientes { get; set; }
    }
}
