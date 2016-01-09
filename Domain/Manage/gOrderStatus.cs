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
    public class gOrderStatus:ICrud<EstadosPedido>
    {
        private Entities db;


        #region Constructors

        public gOrderStatus()
        {
            db = new Entities();
        }

        #endregion

        #region Public methods

        public bool delete(long id)
        {
            try
            {
                var orderStatus = db.EstadosPedido.Find(id);
                db.EstadosPedido.Remove(orderStatus);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }

        public bool edit(EstadosPedido input)
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

        public EstadosPedido getElementById(long id)
        {
            return db.EstadosPedido.Find(id);
        }

        public List<EstadosPedido> getElements()
        {
            return db.EstadosPedido.ToList();
        }

        public bool save(EstadosPedido input)
        {
            try
            {
                db.EstadosPedido.Remove(input);
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
