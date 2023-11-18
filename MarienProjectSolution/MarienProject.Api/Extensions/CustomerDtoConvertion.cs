using MarienProject.Api.Models;
using MarienProject.Models.Dtos;
using System.Net.Security;

namespace MarienProject.Api.Extensions
{
    public static class CustomerDtoConvertion
    {
        public static IEnumerable<CustomerDto> ConvertToDto(this IEnumerable<Customer> customers)
        {
            return (from customer in customers
                    where customer.State != false
                    select new CustomerDto
                    {
                        Id = customer.Id,
                        FirstNames = customer.FirstNames,
                        LastNames = customer.LastNames,
                        Phone = customer.Phone,
                        EmailAddress = customer.EmailAddress,
                        State = customer.State
                    }).ToList();
        }
        public static CustomerDto ConvertToDto(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                FirstNames = customer.FirstNames,
                LastNames = customer.LastNames,
                EmailAddress = customer.EmailAddress,
                State = customer.State,
                Phone = customer.Phone,
            };
        }
    }
}
