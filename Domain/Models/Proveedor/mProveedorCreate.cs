using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Repository;
using System.Web.Mvc;
using Domain.Connection;
using Domain.DefaultValues;

namespace Domain.Models.Proveedor
{
    public class mProveedorCreate:mProveedor
    {
        #region Atributos

        private ConnectionDB conn;
        public SelectList Estados { get; set; }

        #endregion



        #region Constructores

        public mProveedorCreate()
        {
            this.Estado = DefaultStatus.Active;
            this.Fecha_A = DateTime.Now;
            conn = new ConnectionDB();
            Estados = new SelectList(conn.DB.Estados, "IdEstado", "Nombre");

        }


        public mProveedorCreate(Proveedores proveedor)
            :base(proveedor)
        {
            conn = new ConnectionDB();
            Estados = new SelectList(conn.DB.Estados, "IdEstado", "Nombre");
        }

        #endregion


    }
}
