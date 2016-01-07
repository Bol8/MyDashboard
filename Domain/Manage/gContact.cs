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
    public class gContact : ICrud<Contactos>
    {
        private Entities db;

        #region Constructors

        public gContact()
        {
            db = new Entities();
        }
        #endregion



        #region Public methods

        public bool delete(long id)
        {
            try
            {
                var contact = db.Contactos.Find(id);
                db.Contactos.Remove(contact);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }

        public bool edit(Contactos input)
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

        public Contactos getElementById(long id)
        {
            return db.Contactos.Find(id);
        }

        public List<Contactos> getElements()
        {
            return db.Contactos.ToList();
        }

        public bool save(Contactos input)
        {
            try
            {
                db.Contactos.Add(input);
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
