using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain.Interfaces;

namespace Domain.Manage
{
    public class gStatus : ICrud<Estados>
    {
        private Entities db;


        #region Constructors

        public gStatus()
        {
            db = new Entities();
        }

        #endregion



        #region Public methods

        public bool delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool edit(Estados input)
        {
            throw new NotImplementedException();
        }

        public Estados getElementById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Estados> getElements()
        {
            return db.Estados.ToList();
        }

        public bool save(Estados input)
        {
            throw new NotImplementedException();
        }

        #endregion




        #region Private methods

        #endregion








    }
}
