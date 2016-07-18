using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Models.Articulo
{
    public class mArticleCreate : mArticle
    {
        #region Atributos

        public SelectList listaEstados { get; set; }
        public SelectList listaTipos { get; set; }
        public SelectList listIva { get; set; }

        #endregion




    }
}
