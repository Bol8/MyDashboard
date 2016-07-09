using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

namespace Dashboard.Security
{
    public class CustomIdentity : IIdentity
    {
        public IIdentity Identity { get; set; }

        public int idUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int MyProperty { get; set; }
        public string Phone { get; set; }
        public string MvPhone { get; set; }
        public string Mail { get; set; }
        public int Role { get; set; }
        public string RoleName { get; set; }


        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }

        public string Name
        {
            get { return Identity.Name; }
        }
    }
}