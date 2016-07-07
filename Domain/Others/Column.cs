using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Others
{
    public class Column<T> : ICollectionServices<T>
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public int Count { get { return elements.Count; } }
        public List<T> elements { get; set; }


        public Column(string title, string value)
        {
            this.Title = title;
            this.Value = value;
            elements = new List<T>();
        }


        public void Add(T element)
        {
            elements.Add(element);
        }

        public void AddRange(List<T> elements)
        {
            this.elements.AddRange(elements);
        }

        //public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        //{
        //    var result = elements.Where(predicate);
        //}

        public void remove(T element)
        {
            elements.Remove(element);
        }
    }
}
