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
using Dashboard.Security;
using Domain.Models.Lote;

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
            //ModelBinders.Binders.Add(typeof(ModelView), new PersonBinder());
            //RegisterCustomControllerFactory();

            Mapper.Initialize(cfg => {
                cfg.AddProfile(new OrgConfiguration());
            });

            Bootstrapper.Initialise();
            
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                var identity = new CustomIdentity(HttpContext.Current.User.Identity);
                var principal = new CustomPrincipal(identity);
                HttpContext.Current.User = principal;
            }
        }

        private void RegisterCustomControllerFactory()
        {
            IControllerFactory factory = new CustomControlFactory();
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}
