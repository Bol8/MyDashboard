using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace Dashboard.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        //public IIdentity Identity
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public CustomPrincipal(CustomIdentity identity)
        {
            this.Identity = identity;
        }



        public bool IsInRole(string role)
        {
            return Identity is CustomIdentity && string.Compare(role, ((CustomIdentity)Identity).RoleName, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public CustomIdentity CustomIdentity { get { return (CustomIdentity)Identity; } set { Identity = value; } }
        
    }
}