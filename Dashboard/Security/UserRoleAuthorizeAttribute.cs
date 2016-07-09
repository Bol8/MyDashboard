using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using Domain.Interfaces;
using Repository;

namespace Dashboard.Security
{
    public class UserRoleAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
       
        public UserRoleAuthorizeAttribute(IGenericRepository<Roles> gRole)
        {
            Roles = string.Join(",", gRole.GetAll().Select(x => x.Nombre));
        }
        

        /// <summary>
        /// Si el acceso no está autorizado, redireccionamos a otra página.
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
        }

    }
}