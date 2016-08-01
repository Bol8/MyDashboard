using System.Web.Mvc;

namespace Domain.Models.StoreProductProvider
{
    public class MStoreProductProviderCreate : MStoreProductProvider
    {
        public SelectList ListProducts { get; set; }
    }
}
