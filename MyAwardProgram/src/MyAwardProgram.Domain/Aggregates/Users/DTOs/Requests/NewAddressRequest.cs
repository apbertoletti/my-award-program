using MyAwardProgram.Domain.Aggregates.Users.Enums;

namespace MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests
{
    public class NewAddressRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public AddressTypeEnum Type { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
