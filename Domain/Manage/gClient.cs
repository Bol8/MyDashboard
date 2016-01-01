using Repository;
using Domain.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Manage
{
    public class gClient:ICrud<cliente>
    {
        private Entities db;


        #region Constructors

        public gClient()
        {
            db = new Entities();
        }



        #endregion

        #region Public methods

        public bool delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool edit(cliente input)
        {
            throw new NotImplementedException();
        }

        public cliente getElementById(long id)
        {
            return db.cliente.Find(id);
        }

        public List<cliente> getElements()
        {
            return db.cliente.ToList();
        }

        public bool save(cliente input)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private methods

        #endregion

    }
}
