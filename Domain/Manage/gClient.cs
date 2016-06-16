using Repository;
using Domain.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using Elmah;

namespace Domain.Manage
{
    public class gClient:ICrud<Clientes>
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
            try
            {
                var client = db.Clientes.Find(id);
                db.Clientes.Remove(client);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }

        public bool edit(Clientes input)
        {
            throw new NotImplementedException();
        }

        public Clientes getElementById(long id)
        {
            return db.Clientes.Find(id);
        }

        public List<Clientes> getElements()
        {
            return db.Clientes.ToList();
        }

        public bool save(Clientes input)
        {
            try
            {
                input.Fecha_A = DateTime.Now;
                db.Clientes.Add(input);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }

        #endregion

        #region Private methods

        #endregion

    }
}
