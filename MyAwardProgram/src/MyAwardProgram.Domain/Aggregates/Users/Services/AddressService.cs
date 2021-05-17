using MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Users.Entities;
using MyAwardProgram.Domain.Interfaces.Repositories;
using MyAwardProgram.Domain.Interfaces.Services;

namespace MyAwardProgram.Domain.Aggregates.Users.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _AddressRepository;

        public AddressService(
            IAddressRepository AddressRepository)
        {
            _AddressRepository = AddressRepository;
        }

        public NewAddressResponse RegisterAddress(NewAddressRequest newAddressRequest)
        {
            var newAddress = new Address
            {
                UserId = newAddressRequest.UserId,
                Name = newAddressRequest.Name,
                Type = newAddressRequest.Type,
                Description = newAddressRequest.Description,
                City = newAddressRequest.City,
                State = newAddressRequest.State,
                Country = newAddressRequest.Country,
                ZipCode = newAddressRequest.ZipCode
            };

            var addedAddress = _AddressRepository.Add(newAddress);
            _AddressRepository.SaveChanges();

            return new NewAddressResponse
            {
                Id = addedAddress.Id,
                UserId = addedAddress.UserId,
                Name = addedAddress.Name,
                Type = addedAddress.Type,
                Description = addedAddress.Description,
                City = addedAddress.City,
                State = addedAddress.State,
                Country = addedAddress.Country,
                ZipCode = addedAddress.ZipCode
            };
        }
    }
}
