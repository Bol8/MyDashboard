using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    interface ICrud<T>
    {

        T getElementById(long id);

        List<T> getElements();

        bool save(T input);


        bool delete(long id);

        bool edit(T input);

    }
}
