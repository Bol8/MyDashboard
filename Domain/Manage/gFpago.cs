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
    public class gFpago:ICrud<FormaPago>
    {
        private Entities db;

        #region Constructors

        public gFpago()
        {
            db = new Entities();
        }

        #endregion

        #region Public methods

        public bool delete(long id)
        {
            try
            {
                var fPago = db.FormaPago.Find(id);
                db.FormaPago.Remove(fPago);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }

        public bool edit(FormaPago input)
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

        public FormaPago getElementById(long id)
        {
            return db.FormaPago.Find(id);
        }

        public List<FormaPago> getElements()
        {
            return db.FormaPago.ToList();
        }

        public bool save(FormaPago input)
        {
            try
            {
                db.FormaPago.Add(input);
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
