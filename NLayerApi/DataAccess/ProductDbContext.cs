using DataAccess.Entities;

namespace DataAccess;

public class ProductDbContext
{
    public List<Product> Products { get; set; }
    public List<ShoppingCart> ShoppingCarts { get; set; }
}
