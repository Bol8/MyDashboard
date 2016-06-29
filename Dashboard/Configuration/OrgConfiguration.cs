using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Repository;
using Domain.Models.Cliente;

namespace Dashboard.Configuration
{
    public class OrgConfiguration : Profile
    {
        public OrgConfiguration()
        {
            CreateMap<Clientes, mCliente>()
                .ForMember<string>(x => x.sEstado, opt => opt.MapFrom(x => x.Estados.Nombre));
                
            CreateMap<mCliente, Clientes>();
           
        }

    }
}