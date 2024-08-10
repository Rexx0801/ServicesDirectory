namespace Common.Dto
{
    public class ContactDto
    {
        public Guid ContactId { get; set; }
        public string? ContactName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        public string? ContactType { get; set; }
        public bool? IsActive { get; set; }
    }
}
