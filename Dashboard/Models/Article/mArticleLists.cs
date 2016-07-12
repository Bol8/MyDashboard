using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain.Connection;
using Domain.Interfaces;
using Repository;

namespace Dashboard.Models.Article
{
    public class mArticleLists
    {
        private IGenericRepository<TipoProducto> _gArticleType;
        private IGenericRepository<Iva> _gIVA;
        private IGenericRepository<Estados> _gStatus;

        public SelectList Estados { get; set; }
        public SelectList Tipos { get; set; }
        public SelectList IVA { get; set; }


        #region Constructores

        public mArticleLists(IGenericRepository<TipoProducto> gArticleType, IGenericRepository<Iva> gIva,
                             IGenericRepository<Estados> gStatus)
        {
            Estados = new SelectList(_gStatus.GetAll().ToList(), "Id", "Nombre");
            Tipos = new SelectList(_gArticleType.GetAll().ToList(), "Id", "Nombre");
            IVA = new SelectList(_gIVA.GetAll().ToList(), "Id", "Valor");
        }

        #endregion

    }
}