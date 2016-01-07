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
    public class gProduct:ICrud<Articulos>
    {
        private Entities db;

        #region Constructors

        public gProduct()
        {
            db = new Entities();
        }

        #endregion

        #region Public methods

        public bool delete(long id)
        {
            try
            {
                var product = db.Articulos.Find(id);
                db.Articulos.Remove(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }

        public bool edit(Articulos input)
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

        public Articulos getElementById(long id)
        {
            return db.Articulos.Find(id);
        }

        public List<Articulos> getElements()
        {
            return db.Articulos.ToList();
        }


        public bool save(Articulos input)
        {
            try
            {
                db.Articulos.Add(input);
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
