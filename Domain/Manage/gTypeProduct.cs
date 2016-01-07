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
    public class gTypeProduct : ICrud<TipoProducto>
    {
        private Entities db;
        

        #region Constructors

        public gTypeProduct()
        {
            db = new Entities();
        }


        #endregion

        #region Public methods

        public bool delete(long id)
        {
            try
            {
                var typeProduct = db.TipoProducto.Find(id);
                db.TipoProducto.Remove(typeProduct);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }

        public bool edit(TipoProducto input)
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



        public TipoProducto getElementById(long id)
        {
            return db.TipoProducto.Find(id);
        }

        public List<TipoProducto> getElements()
        {
            return db.TipoProducto.ToList();
        }

        public bool save(TipoProducto input)
        {
            try
            {
                db.TipoProducto.Add(input);
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
