using System.Web.Mvc;

namespace Domain.Models.StoreProductProvider
{
    public class MStoreProductProviderCreate : MStoreProductProvider
    {
        public SelectList ListProviders { get; set; }
        public SelectList ListProducts { get; set; }
    }
}
