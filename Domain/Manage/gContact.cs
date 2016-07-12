using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain.Interfaces;
using Elmah;
using System.Data.Entity;
using Domain.Connection;


namespace Domain.Manage
{
    public class gContact : GenericRepository<Entities,Contactos>
    {
        public gContact() { }
    }
}
