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
using Domain.Models.AlmacenProducto;

namespace Dashboard.Configuration
{
    public class OrgConfiguration : Profile
    {
        public OrgConfiguration()
        {
            CreateMap<Clientes, mCliente>()
                .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));
            CreateMap<Clientes, mClientCreate>()
               .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));
            CreateMap<mCliente, Clientes>();

            CreateMap<Proveedores, mProveedor>()
              .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));
            CreateMap<Proveedores, mProveedorCreate>()
               .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));
            CreateMap<mProveedor, Proveedores>();

            CreateMap<Contactos, mContact>();
            CreateMap<mContact, Contactos>();

            CreateMap<Articulos, mArticle>()
                .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre))
                .ForMember<string>(x => x.sIVA, opt => opt.MapFrom(x => x.Iva1.Valor))
                .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));

            CreateMap<mArticle, Articulos>();

            CreateMap<Almacen_Productos, mAlmacenProducto>()
                .ForMember<mArticle>(x => x.Article, opt => opt.MapFrom(x =>
                new mArticle {
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

            CreateMap<mStoreArticleCreate, Articulos>();
            CreateMap<mStoreArticleCreate, Almacen_Productos>();

        }

    }
}