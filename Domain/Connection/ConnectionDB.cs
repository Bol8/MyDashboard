using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using System.Data.Entity;


namespace Domain.Connection
{
    public class ConnectionDB : IDisposable
    {
        #region Atributos

        private Entities db;

        public Entities DB { get { return db; } }

        #endregion


        #region Constructores

        public ConnectionDB(DbContext context)
        {
            if (context is Entities)
            {
                db = (Entities)context;
            }
           

        }

        public ConnectionDB()
        {

            db = new Entities();
        }

        #endregion


        public void Dispose()
        {
            db.Dispose();
        }
    }
}