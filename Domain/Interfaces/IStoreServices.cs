using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStoreServices
    {
        bool checkMinStock(long id);

        bool checkStock(long id);

    }
}
