using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using Domain.Interfaces;
using Repository;
using Domain.Manage;

namespace Dashboard.Security
{
    public class CustomRoleProvider : RoleProvider
    {

        private int _cacheTimeoutInMinutes = 300;
        private IGenericRepository<Usuarios> _gUser = new gUser();

        public CustomRoleProvider() { }

        //public CustomRoleProvider(IGenericRepository<Usuarios> gUser)
        //{
        //    this._gUser = gUser;
        //}

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            else
            {
                var cacheKey = string.Format("UserRoles_{0}", username);
                if (HttpRuntime.Cache[cacheKey] != null)
                {
                    return (string[])HttpRuntime.Cache[cacheKey];
                }
                else
                {
                    var userRoles = new string[] { };
                    var user = _gUser.FindBy(x => string.Compare(x.UserName, username, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();

                    if (user != null) userRoles = new[] { user.Roles.Nombre };
                    HttpRuntime.Cache.Insert(cacheKey, userRoles, null, DateTime.Now.AddMinutes(_cacheTimeoutInMinutes), Cache.NoSlidingExpiration);

                    return userRoles.ToArray();
                }
                
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRoles = GetRolesForUser(username);
            return userRoles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}