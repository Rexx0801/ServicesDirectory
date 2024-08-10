using BusinessLayer.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace NLayerApi.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost]
    public async Task<bool> CreateProductAsync(CreateProductModel model)
    {
        return await productService.CreateProductAsync(model);
    }

    [HttpGet]
    public async Task<GetProductResultModel> GetProductAsync(int productId)
    {
        return await productService.GetProductAsync(productId);
    }
}
