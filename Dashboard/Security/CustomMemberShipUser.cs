using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Repository;

namespace Dashboard.Security
{
    public class CustomMembershipUser : MembershipUser
    {
        public int idUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string UserName { get; set; }
        public string Phone { get; set; }
        //public string MvPhone { get; set; }
        public string Mail { get; set; }
        public int Role { get; set; }
        public string RoleName { get; set; }


        public CustomMembershipUser(Usuarios user)
            :base("CustomMembershipProvider",user.UserName, user.IdUsuario,user.Email , string.Empty , 
                  string.Empty, true , false, DateTime.Now , DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            idUser = user.IdUsuario;
            FirstName = user.Nombre;
            LastName = user.Apellidos;
            Role = user.idRol;
            RoleName = user.Roles.Nombre;
            Phone = user.Telefono;
        }
    }
}