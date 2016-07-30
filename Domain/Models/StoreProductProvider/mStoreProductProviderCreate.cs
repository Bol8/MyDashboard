using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Models.StoreProductProvider
{
    public class mStoreProductProviderCreate : mStoreProductProvider
    {
  
        public SelectList ListProducts { get; set; }    
        
        public mStoreProductProviderCreate() { }  
        
    }
}
