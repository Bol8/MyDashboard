using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICollectionServices<T>
    {
        void Add(T element);
        // IQueryable<T> Find(Expression<Func<T,bool>> predicate);
        void remove(T element);
        void AddRange(List<T> elements);
        
    }
}
