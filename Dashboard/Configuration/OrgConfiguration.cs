using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Repository;
using Domain.Models.Cliente;
using Domain.Models.Proveedor;
using Domain.Models.Contact;
using Domain.Models.Articulo;
using Domain.Models.PedidoC;
using Domain.Models.AlmacenProducto;
using System.Web.Mvc;

namespace Dashboard.Configuration
{
    public class OrgConfiguration : Profile
    {
        public OrgConfiguration()
        {
            configureClients();
            configureProviders();
            configureContacts();
            configureArticles();
            configureClientOrder();
            
        }


        private void configureClients()
        {
            CreateMap<Clientes, mCliente>()
                .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));
            CreateMap<Clientes, mClientCreate>()
               .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));
            CreateMap<mCliente, Clientes>();
        }

        private void configureProviders()
        {
            CreateMap<Proveedores, mProveedor>()
             .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));
            CreateMap<Proveedores, mProveedorCreate>()
               .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));
            CreateMap<mProveedor, Proveedores>();
        }

        private void configureContacts()
        {
            CreateMap<Contactos, mContact>();
            CreateMap<mContact, Contactos>();
        }

        private void configureArticles()
        {
            CreateMap<Articulos, mArticle>()
               .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre))
               .ForMember<string>(x => x.sIVA, opt => opt.MapFrom(x => x.Iva1.Valor))
               .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));

            CreateMap<Articulos, mArticleCreate>()
              .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre))
              .ForMember<string>(x => x.sIVA, opt => opt.MapFrom(x => x.Iva1.Valor))
              .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre))
               //.ForMember<string>(x => x.Stock, opt => opt.MapFrom(x => x.S))
              ;



            CreateMap<mArticle, Articulos>();


            CreateMap<Almacen_Productos, mAlmacenProducto>()
                .ForMember<mArticle>(x => x.Article, opt => opt.MapFrom(x =>
                new mArticle
                {
                    IdArticulo = x.Articulos.IdArticulo,
                    Codigo = x.Articulos.Codigo,
                    Nombre = x.Articulos.Nombre,
                    Peso = x.Articulos.Peso,
                    Precio = x.Articulos.Precio,
                    Tipo = x.Articulos.Tipo,
                    sTipo = x.Articulos.TipoProducto.Nombre,
                    Estado = x.Articulos.Estado,
                    sEstado = x.Articulos.Estados.Nombre,
                    IVA = x.Articulos.IVA,
                    sIVA = x.Articulos.Iva1.Valor.ToString(),
                    Descripcion = x.Articulos.Descripcion,
                    stockMax = x.Articulos.StockMax,
                    stockMin = x.Articulos.StockMin
           
                }));


            CreateMap<Almacen_Productos, mStoreArticleCreate>()
               //.ForMember<int>(x => x., opt => opt.MapFrom(x => x.Articulos.IdArticulo))
               ;


            CreateMap<mStoreArticleCreate, Articulos>()
                .ForMember<Estados>(x => x.Estados, opt => opt.Ignore())
                .ForMember<Iva>(x => x.Iva1, opt => opt.Ignore())
                .ForMember<TipoProducto>(x => x.TipoProducto, opt => opt.Ignore());

            CreateMap<mStoreArticleCreate, Almacen_Productos>();
        }

        private void configureClientOrder()
        {
            CreateMap<Pedido_c, mPedidoC>()
                .ForMember<string>(x => x.clienteNombre, opt => opt.MapFrom(x => x.Clientes.Razon_Social))
                .ForMember<string>(x => x.sForma_pago, opt => opt.MapFrom(x => x.FormaPago.Nombre))
                .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.EstadosPedido.Nombre))
                .ForMember<decimal>(x => (decimal)x.Importe, opt => opt.MapFrom(x => x.Linea_pedido_c.Sum(y => y.Cantidad * y.Almacen_Productos.Articulos.Precio)))
                .ForMember<decimal>(x => (decimal)x.Peso, opt => opt.MapFrom(x => x.Linea_pedido_c.Sum(y => (y.Cantidad * y.Almacen_Productos.Articulos.Peso)/1000)))
                ;

            CreateMap<Pedido_c, mPedidoCCreate>();

            CreateMap<Linea_pedido_c, mOrderLine>()
                .ForMember<string>(x => x.sArticulo, opt => opt.MapFrom(x => x.Almacen_Productos.Articulos.Nombre))
                .ForMember<decimal>(x => x.Precio , opt => opt.MapFrom(x => x.Almacen_Productos.Articulos.Precio))
                .ForMember<decimal>(x => x.Peso, opt => opt.MapFrom(x => x.Almacen_Productos.Articulos.Peso))
                .ForMember<decimal>(x => (decimal) x.Total, opt => opt.MapFrom(x => (x.Almacen_Productos.Articulos.Precio * x.Cantidad)))
                .ForMember<decimal>(x => x.TotalPeso, opt => opt.MapFrom(x => ((x.Almacen_Productos.Articulos.Peso * x.Cantidad)/1000)))
                ;

        }

    }
}