namespace Common.Dto
{
    public class AddressDto
    {
        public Guid AddressId { get; set; }
        public string PostCode { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public Guid TownId { get; set; }
    }
}
