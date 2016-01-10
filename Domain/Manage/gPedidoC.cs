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
    public class gPedidoC:ICrud<Pedido_c>
    {

        private Entities db;

        #region Constructors

        public gPedidoC()
        {
            db = new Entities();
        }
        #endregion




        #region Public methods

        public bool delete(long id)
        {
            try
            {
                var pedidoC = db.Pedido_c.Find(id);
                db.Pedido_c.Remove(pedidoC);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }

        public bool edit(Pedido_c input)
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


        public Pedido_c getElementById(long id)
        {
            return db.Pedido_c.Find(id);
        }


        public List<Pedido_c> getElements()
        {
            return db.Pedido_c.ToList();
        }

        public bool save(Pedido_c input)
        {
            try
            {
                db.Pedido_c.Add(input);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }

            return true;
        }


        public Pedido_c create(Pedido_c input)
        {
            try
            {
                db.Pedido_c.Add(input);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return null;
            }

            return input;
        }

        #endregion




        #region Private methods

        #endregion





    }
}
