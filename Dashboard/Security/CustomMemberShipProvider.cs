using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Repository;
using System.Collections.Specialized;
using System.Web.Caching;
using Domain.Interfaces;
using Domain.Manage;

namespace Dashboard.Security
{
    public class CustomMembershipProvider : MembershipProvider
    {

        private int _cacheTimeoutInMinutes = 300;
        private IGenericRepository<Usuarios> _gUser = new gUser();

        public CustomMembershipProvider() { }

        //public CustomMembershipProvider(IGenericRepository<Usuarios> gUser)
        //{
        //    this._gUser = gUser;
        //}


        /// <summary>
        /// Inicializa valores del web.config.
        /// </summary>
        /// <param name="name">Nombre del proveedor.</param>
        /// <param name="config">Colección de pares nombre/valor que representan los atributos específicos en la configuración de este proveedor.</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            // Set Properties
            
            int val;
            if (!string.IsNullOrEmpty(config["cacheTimeoutInMinutes"]) && Int32.TryParse(config["cacheTimeoutInMinutes"], out val))
            {
                _cacheTimeoutInMinutes = val;
            }

            // Call base method
            base.Initialize(name, config);
        }

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

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var cacheKey = string.Format("UserData_{0}", username);

            if (HttpRuntime.Cache[cacheKey] != null)
            {
                return (CustomMembershipUser)HttpRuntime.Cache[cacheKey];
            }
            else
            {
                var user = _gUser.FindBy(x => string.Compare(x.UserName, username, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
                if (user == null) return null;

                var membershipUser = new CustomMembershipUser(user);
                HttpRuntime.Cache.Insert(cacheKey, membershipUser, null, DateTime.Now.AddMinutes(_cacheTimeoutInMinutes), Cache.NoSlidingExpiration);
                return membershipUser;
            }
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var user = _gUser.FindBy(x => x.UserName.Equals(username) && x.Password.Equals(password));
            if (user == null) return false;
            return true;
        }
    }
}