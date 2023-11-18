using MarienProject.Api.Models;

namespace MarienProject.Api.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<bool> CreateCustomer(Customer newCustomer);
        Task<bool> UpdateCustomer(Customer updatedCustomer);
        Task<bool> DeleteCustomer(int id);
    }
}
