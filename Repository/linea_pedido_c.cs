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
    
    public partial class Linea_pedido_c
    {
        public int Num_ped { get; set; }
        public int Linea { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public int IdArticulo { get; set; }
    
        public virtual Pedido_c Pedido_c { get; set; }
        public virtual Articulos Articulos { get; set; }
    }
}
