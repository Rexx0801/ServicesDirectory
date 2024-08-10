using BusinessLayer.Interfaces;
using Common.Models;

namespace NLayerApi.Controllers;

public class ShoppingCartController(IProductService service)
{

    Task<GetShoppingCartResultModel> GetShoppingCartDetailsAsync()
    {
        return service.GetShoppingCartDetailsAsync();
    }
}
