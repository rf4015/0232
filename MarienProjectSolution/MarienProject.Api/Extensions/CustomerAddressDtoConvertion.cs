using MarienProject.Api.Models;
using MarienProject.Models.Dtos;

namespace MarienProject.Api.Extensions
{
    public static class CustomerAddressDtoConvertion
    {
        public static IEnumerable<CustomerAddressDto> ConvertToDto(this IEnumerable<CustomerAddress> addresses)
        {
            return (from address in addresses
                    select new CustomerAddressDto
                    {
                        Id = address.Id,
                        MunicipalityId = address.MunicipalityId,
                        Address = address.Address,
                        Residence = address.Residence,
                        PostalCode = address.PostalCode,
                    }).ToList();
        }
    }
}
