using System.Collections.Generic;

namespace CommerceDomain
{
    public abstract class ProductRepository
    {
        public abstract IEnumerable<Product> GetFeaturedProducts();
    }
}