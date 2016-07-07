using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Dashboard.Models;
using Dashboard.ModelBinding;
using AutoMapper;
using Domain.Models.Cliente;
using Repository;
using Dashboard.Configuration;
using Autofac;
using Domain.Manage;
using Domain.Interfaces;
using Dashboard.Controllers;
using System.Reflection;
using Dashboard.CustomControllers;


namespace Dashboard
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(PruebaBinder), new ContactBinder());
            //RegisterCustomControllerFactory();

            Mapper.Initialize(cfg => {
                cfg.AddProfile(new OrgConfiguration());
            });

            Bootstrapper.Initialise();


            //var builder = new ContainerBuilder();
            //builder.RegisterInstance(new gClient()).As<IGenericRepository<Clientes>>();
            //builder.RegisterType<ClientController>();



            // builder.RegisterControllers(Assembly.GetExecutingAssembly()).InjectActionInvoker();

            //builder.RegisterAssemblyTypes(
            //    Assembly.GetExecutingAssembly())
            //    .Where(x => !x.IsAbstract && typeof(Controller).IsAssignableFrom(x))
            //    .InstancePerMatchingLifetimeScope(DependencyResolver.Current);


           
            //var container = builder.Build();
            // DependencyResolver.SetResolver(container);

            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var service = scope.Resolve<ClientController>();
            //}
            
        }



        private void RegisterCustomControllerFactory()
        {
            IControllerFactory factory = new CustomControlFactory();
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}
