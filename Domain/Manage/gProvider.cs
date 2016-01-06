using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain.Interfaces;
using Elmah;
using System.Data.Entity;

namespace Domain.Manage
{
    public class gProvider : ICrud<Proveedores>
    {

        private Entities db;

        #region Constructors

        public gProvider()
        {
            db = new Entities();
        }

        #endregion

        #region Public methods




        public bool delete(long id)
        {
            try
            {
                var provider = db.Proveedores.Find(id);
                db.Proveedores.Remove(provider);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }



        public bool edit(Proveedores input)
        {
            try
            {
                db.Entry(input).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public Proveedores getElementById(long id)
        {
            return db.Proveedores.Find(id);
        }


        public List<Proveedores> getElements()
        {
            return db.Proveedores.ToList();
        }


        public bool save(Proveedores input)
        {
            try
            {
                db.Proveedores.Add(input);
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
