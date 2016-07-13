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
                }));

            CreateMap<Almacen_Productos, mStoreArticleCreate>()
               .ForMember<int>(x => x.IdArticulo, opt => opt.MapFrom(x => x.Articulos.IdArticulo))
               .ForMember<string>(x => x.Codigo, opt => opt.MapFrom(x => x.Articulos.Codigo))
               .ForMember<string>(x => x.Nombre, opt => opt.MapFrom(x => x.Articulos.Nombre))
               .ForMember<decimal?>(x => x.Peso, opt => opt.MapFrom(x => x.Articulos.Peso))
               .ForMember<int>(x => x.Tipo, opt => opt.MapFrom(x => x.Articulos.Tipo))
               .ForMember<int>(x => x.Estado, opt => opt.MapFrom(x => x.Articulos.Estado))
               .ForMember<decimal>(x => x.Precio, opt => opt.MapFrom(x => x.Articulos.Precio))
               .ForMember<int>(x => x.IVA, opt => opt.MapFrom(x => x.Articulos.IVA))
               .ForMember<string>(x => x.Descripcion, opt => opt.MapFrom(x => x.Articulos.Descripcion))
               .ForMember<decimal>(x => x.Precio, opt => opt.MapFrom(x => x.Articulos.Precio))
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
                .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.EstadosPedido.Nombre));

            CreateMap<Pedido_c, mPedidoCCreate>();
            CreateMap<Linea_pedido_c, mOrderLine>();

        }

    }
}