using BusinessLayer.Interfaces;
using Common.Dto;
using Common.Models;
using DataAccess;
using DataAccess.Entities;

namespace BusinessLayer.Services;

public class ProductService(ProductDbContext context, AutoMapper.Mapper mapper) : IProductService
{

    public async Task<bool> CreateProductAsync(CreateProductModel model)
    {
        Product product = mapper.Map<Product>(model.Product);
        context.Products.Add(product);
        return 1 > 0;
    }

    public async Task<GetProductResultModel> GetProductAsync(int productId)
    {
        Product? product = context.Products.Find(p => p.ProductId == productId);
        return new GetProductResultModel
        {
            Product = mapper.Map<ProductDto>(product)
        };
    }

    public async Task<GetShoppingCartResultModel> GetShoppingCartDetailsAsync()
    {
        List<ShoppingCart> contextShoppingCarts = context.ShoppingCarts;

        List<string> result = contextShoppingCarts.Select(shoppingCart => shoppingCart.ProductName).ToList();
        return new GetShoppingCartResultModel
        {
            ProductNames = result
        };
    }
}
