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
    public class gLineaPedidoC : ICrud<Linea_pedido_c>
    {
        private Entities db;

        #region Constructors

        public gLineaPedidoC()
        {
            db = new Entities();
        }

        #endregion


        #region Public methods

        public bool delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool edit(Linea_pedido_c input)
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

        public Linea_pedido_c getElementById(long id)
        {
            return db.Linea_pedido_c.Find(id);
        }

        public List<Linea_pedido_c> getElements()
        {
            return db.Linea_pedido_c.ToList();
        }


        public List<Linea_pedido_c> getElementsById(int numPed)
        {
            var orderLines = db.Linea_pedido_c.Where(x => x.Num_ped == numPed).ToList();

            return orderLines;
        }


        public bool save(Linea_pedido_c input)
        {
            throw new NotImplementedException();
        }

        #endregion



        #region Private methods

        #endregion




    }
}
