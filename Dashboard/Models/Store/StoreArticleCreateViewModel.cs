using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Domain.Models.AlmacenProducto;
using Dashboard.Models.Article;

namespace Dashboard.Models.Store
{
    public class StoreArticleCreateViewModel
    {
        public mAlmacenProducto StoreArticle { get; set; }

        public mArticleLists ArticleLists { get; set; }
    }
}