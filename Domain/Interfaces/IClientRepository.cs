using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Domain.Interfaces
{
    public interface IClientRepository:IGenericRepository<Clientes>
    {
        Clientes getSingle(long id);
    }
}
