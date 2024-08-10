using Common.Dto;

namespace Common.Models;

public class GetProductResultModel
{
    public ProductDto Product { get; set; }
    public AddressDto FactoryAddress { get; set; }
}
