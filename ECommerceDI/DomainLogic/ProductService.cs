using System.Collections.Generic;
using System.Linq;
using SqlDataAccess;

namespace DomainLogic
{
    public class ProductService
    {
        private readonly CommerceObjectContext _objectContext;

        public ProductService()
        {
            _objectContext = new CommerceObjectContext();
        }

        public IEnumerable<Product> GetFeaturedProducts(
            bool isCustomerPreferred)
        {
            var discount = isCustomerPreferred ? .95m : 1;
            var products = (from p in _objectContext
                                .Products
                            where p.IsFeatured
                            select p).AsEnumerable();
            return from p in products
                   select new Product
                          {
                              ProductId = p.ProductId,
                              Name = p.Name,
                              Description = p.Description,
                              IsFeatured = p.IsFeatured,
                              UnitPrice = p.UnitPrice * discount
                          };
        }
    }
}