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
    public class gIVA : ICrud<Iva>
    {
        private Entities db;

        #region Constructors

        public gIVA()
        {
            db = new Entities();
        }

        #endregion

        #region Public methods

        public bool delete(long id)
        {
            try
            {
                var iva = db.Iva.Find(id);
                db.Iva.Remove(iva);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }


        public bool edit(Iva input)
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


        public Iva getElementById(long id)
        {
            return db.Iva.Find(id);
        }

        public List<Iva> getElements()
        {
            return db.Iva.ToList();
        }

        public bool save(Iva input)
        {
            try
            {
                db.Iva.Add(input);
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
