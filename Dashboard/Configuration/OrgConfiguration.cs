using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Repository;
using Domain.Models.Cliente;
using Domain.Models.Proveedor;
using Domain.Models.Contact;

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

        }

    }
}