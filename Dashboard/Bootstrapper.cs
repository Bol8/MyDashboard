using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Domain.Interfaces;
using Dashboard.Controllers;
using Repository;
using Domain.Manage;
using System.Linq.Expressions;
using System.Linq;
using System;
using Dashboard.Security;

namespace Dashboard
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IGenericRepository<Articulos>, gProduct>();
            container.RegisterType<IGenericRepository<Contactos>, gContact>();
            container.RegisterType<IGenericRepository<Proveedores>, gProveedor>();
            container.RegisterType<IGenericRepository<Clientes>, gClient>();
            container.RegisterType<IGenericRepository<Estados>, gStatus>();
            container.RegisterType<IGenericRepository<Iva>, gIVA>();
            container.RegisterType<IGenericRepository<TipoProducto>, gTypeProduct>();
            container.RegisterType<IGenericRepository<Usuarios>, gUser>();
            container.RegisterType<IGenericRepository<Empresas>, gCompany>();


            container.RegisterType<ClientController>(new InjectionConstructor(new ResolvedParameter<gClient>("repo"),
                                                                              new ResolvedParameter<gStatus>("st"))
                                                                              );

           
            container.RegisterType<ProveedorController>(new InjectionConstructor(new ResolvedParameter<gProveedor>("gProveedor"),
                                                                                 new ResolvedParameter<gStatus>("gStatus"))
                                                                              );

            
            container.RegisterType<ContactController>(new InjectionConstructor(new ResolvedParameter<gContact>("gContact")));

            
            container.RegisterType<StoreController>(new InjectionConstructor(new ResolvedParameter<gProduct>("gArticle")));


            container.RegisterType<ArticleController>(new InjectionConstructor(new ResolvedParameter<gProduct>("gArticle"),
                                                                              new ResolvedParameter<gTypeProduct>("gArticleType"),
                                                                              new ResolvedParameter<gIVA>("gIVA"),
                                                                              new ResolvedParameter<gStatus>("gStatus"))
                                                                              );

            container.RegisterType<HomeController>(new InjectionConstructor(new ResolvedParameter<gUser>("gUser"),
                                                                             new ResolvedParameter<gCompany>("gCompany"))
                                                                             );

            //container.RegisterType<CustomRoleProvider>(new InjectionConstructor(new ResolvedParameter<gUser>("gUser")));
            //container.RegisterType<CustomMembershipProvider>(new InjectionConstructor(new ResolvedParameter<gUser>("gUser")));
            




            return container;
        }
    }
}