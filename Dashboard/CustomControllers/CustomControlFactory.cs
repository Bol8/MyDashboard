using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Domain.Interfaces;
using Domain.Connection;
using Repository;
using Domain.Manage;
using Dashboard.Controllers;

namespace Dashboard.CustomControllers
{
    public class CustomControlFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            IGenericRepository<Clientes> _gnr = new gClient();

          //  var controller = new ClientController(_gnr);

            return null;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}