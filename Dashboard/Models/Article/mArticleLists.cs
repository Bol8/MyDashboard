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
        public SelectList Estados { get; set; }
        public SelectList Tipos { get; set; }
        public SelectList IVA { get; set; }


        public mArticleLists(IGenericRepository<TipoProducto> gArticleType, IGenericRepository<Iva> gIva,
                             IGenericRepository<Estados> gStatus)
        {
            Estados = new SelectList(gStatus.GetAll().ToList(), "Id", "Nombre");
            Tipos = new SelectList(gArticleType.GetAll().ToList(), "Id", "Nombre");
            IVA = new SelectList(gIva.GetAll().ToList(), "Id", "Valor");
        }

    }
}