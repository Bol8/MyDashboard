using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStatusRepository:IGenericRepository<Estados>
    {
        Estados getSingle(long id);
    }
}
