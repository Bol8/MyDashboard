﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Albaranes> Albaranes { get; set; }
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Contactos> Contactos { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<EstadosPedido> EstadosPedido { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<Iva> Iva { get; set; }
        public virtual DbSet<linea_factura> linea_factura { get; set; }
        public virtual DbSet<Linea_pedido_c> Linea_pedido_c { get; set; }
        public virtual DbSet<Linea_pedido_p> Linea_pedido_p { get; set; }
        public virtual DbSet<Pedido_c> Pedido_c { get; set; }
        public virtual DbSet<Pedido_p> Pedido_p { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Tarifas> Tarifas { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
