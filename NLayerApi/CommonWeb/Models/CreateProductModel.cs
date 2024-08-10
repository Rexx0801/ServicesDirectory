using Common.Dto;

namespace Common.Models;

public class CreateProductModel
{
    public ProductDto Product { get; set; }
    public AddressDto FactoryAddress { get; set; }
}
