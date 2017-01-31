using Domain = CommerceDomain;
namespace CommerceSqlDataAccess
{
    public partial class Product
    {
        public Domain.Product ToDomainProduct()
        {
            Domain.Product p = new Domain.Product();
            p.Name = this.Name;
            p.UnitPrice = this.UnitPrice;
            return p;
        }
    }
}