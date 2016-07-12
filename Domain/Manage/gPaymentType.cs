using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain.Connection;

namespace Domain.Manage
{
    public class gPaymentType : GenericRepository<Entities , FormaPago>
    {
        public gPaymentType() { }
    }
}
