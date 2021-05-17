using MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses;

namespace MyAwardProgram.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        NewAddressResponse RegisterAddress(NewAddressRequest newAddressRequest);
    }
}
