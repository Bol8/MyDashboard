using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain.Interfaces;
using GenericRepository.Repository;

namespace Domain.Manage
{
    public class gStatus:GenericRepository<Entities,Estados>,IStatusRepository
    {
        public gStatus() { }

        public Estados getSingle(long id)
        {
            throw new NotImplementedException();
        }
    }
}
