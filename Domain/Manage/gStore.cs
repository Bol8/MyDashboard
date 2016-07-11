using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Connection;
using Repository;

namespace Domain.Manage
{
    public class gStore : GenericRepository<Entities ,Almacenes>
    {
        public gStore() { }
    }
}
