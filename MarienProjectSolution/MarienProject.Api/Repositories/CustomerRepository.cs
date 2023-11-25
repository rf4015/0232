using MarienProject.Api.Models;
using MarienProject.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MarienProject.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MarienPharmacyContext _dbFarmaciaContext;
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(MarienPharmacyContext dbFarmaciaContext, ILogger<CustomerRepository> logger)
        {
            _dbFarmaciaContext = dbFarmaciaContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                var customers = await _dbFarmaciaContext.Customers
                                        .Include(c => c.CustomerAddresses)
                                        .Where(c => c.State == true)
                                        .ToArrayAsync();
                                        
                return customers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all customers");

                return null;
            }

            //var customer = await _dbFarmaciaContext.Customers.FromSqlRaw("uspGetAllCustomers").Include(c => c.CustomerAddresses).ToArrayAsync();
            //return customer;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                var customer = await _dbFarmaciaContext.Customers
                                   .SingleOrDefaultAsync(c => c.Id == id);
                if(customer == null)
                {
                    throw new Exception("Customer not found");
                }
                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting customer");
                return null;
            }
        }
        public async Task<bool> CreateCustomer(Customer customer, UserProfile user)
        {
            try
            {
                //var id =  _dbFarmaciaContext.UserProfiles.Max(c => c.Id);

                //if (customer.UserId == id)
                //{
                //    return false;
                //}

                //customer.UserId = id;
                //_dbFarmaciaContext.Customers.Add(customer);
                //await _dbFarmaciaContext.SaveChangesAsync();

                var result = await _dbFarmaciaContext.Database.ExecuteSqlRawAsync($"uspCreateCustomer @UserName = '{user.UserName}', @UserPassword = '{user.UserPassaword}', @ProfileImage = '{user.ProfileImage}', @FirstNames = '{customer.FirstNames}', @LastNames = '{customer.LastNames}', @Phone = '{customer.Phone}', @EmailAddress = '{customer.EmailAddress}'");

                if(result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the customer: ", ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateCustomer(Customer customerToUpdate)
        {
            Customer customer = await _dbFarmaciaContext.Customers.FirstOrDefaultAsync(c => c.Id == customerToUpdate.Id);

            if (customer != null)
            {
                try
                {
                    customer.FirstNames = customerToUpdate.FirstNames;
                    customer.LastNames = customerToUpdate.LastNames;
                    customer.Phone = customerToUpdate.Phone;
                    customer.EmailAddress = customerToUpdate.EmailAddress;

                    _dbFarmaciaContext.Entry(customer).State = EntityState.Modified;

                    await _dbFarmaciaContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while updating the customer");
                    return false;
                }
            }
            return false;
        }
        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _dbFarmaciaContext.Customers.FirstOrDefaultAsync(c => c.Id == id);

            if (customer != null)
            {
                try
                {
                    var user = await _dbFarmaciaContext.UserProfiles.FirstOrDefaultAsync(c => c.Customer.Id == id);

                    customer.State = false;
                    _dbFarmaciaContext.Customers.Entry(customer).State = EntityState.Modified;
                    await _dbFarmaciaContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while deleting the customer");
                    return false;
                }
            }
            return false;
        }
    }

}
