using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain.Interfaces;
using Elmah;
using System.Data.Entity;
using Domain.Connection;

namespace Domain.Manage
{
    public class gProveedor : ICrud<Proveedores>
    {

        private Entities db;

        private ConnectionDB conn;

        #region Constructores

        public gProveedor()
        {
            conn = new ConnectionDB();
            db = new Entities();
        }

        #endregion

        #region Public methods




        public bool delete(long id)
        {
            try
            {
                var provider = conn.DB.Proveedores.Find(id);
                conn.DB.Proveedores.Remove(provider);
                conn.DB.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                conn.DB.Dispose();
                return false;
            }

            return true;
        }



        public bool edit(Proveedores input)
        {
            try
            {
                conn.DB.Entry(input).State = EntityState.Modified;
                conn.DB.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                conn.DB.Dispose();
                return false;
            }

            return true;
        }


        public Proveedores getElementById(long id)
        {
            return conn.DB.Proveedores.Find(id);
        }


        public List<Proveedores> getElements()
        {
            return conn.DB.Proveedores.ToList();
        }


        public bool save(Proveedores input)
        {
            try
            {
                input.Fecha_A = DateTime.Now;

                conn.DB.Proveedores.Add(input);
                conn.DB.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                conn.DB.Dispose();
                return false;
            }

            return true;
        }
        #endregion

        #region Private methods

        #endregion

    }
}
