using MarienProject.Api.Models;
using MarienProject.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MarienProject.Api.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MarienPharmacyContext _dbPharmacyContext;
        private readonly ILogger<SaleRepository> _logger;

        public SaleRepository(MarienPharmacyContext dbPharmacyContext, ILogger<SaleRepository> logger)
        {
            _dbPharmacyContext = dbPharmacyContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            try
            {
                var sales = await _dbPharmacyContext.Sales
                            .Include(s => s.Customer)
                            .Include(s => s.InvoiceStatus)
                            .Include(s => s.DeliveryType)
                            .Where(s => s.InvoiceStatusId != 3).ToArrayAsync();

                return sales;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all Sales");
                return null;
            }
        }

        public async Task<bool> CreateSale(Sale sale)
        {
            try
            {
                _dbPharmacyContext.Sales.Add(sale);
                await _dbPharmacyContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error ocurre while creating a new sale");
                return false;
            }
        }

        public async Task<Sale> GetSaleById(int id)
        {
            try
            {
                var sale = await _dbPharmacyContext.Sales.FirstOrDefaultAsync(s => s.Id == id);

                if (sale == null)
                {
                    throw new Exception("Sale not found");
                }
                return sale;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting sale");
                return null;
            }
        }

        public async Task<bool> UpdateSale(int id, Sale updatedSale)
        {
            try
            {
                var sale = await _dbPharmacyContext.Database.ExecuteSqlRawAsync($"uspUpdateSale @Id_Sale = {id} , @Id_Customer = {updatedSale.CustomerId} , @Id_InvoiceStatus = {updatedSale.InvoiceStatusId} , @Id_DeliveryType = {updatedSale.DeliveryTypeId} , @Id_Employee = {updatedSale.EmployeeId} , @Id_DeliveryEmployee = {updatedSale.DeliveryEmployeeId} , @Id_Municipality = {updatedSale.MunicipalityId} , @Address = {updatedSale.Address} , @Residence = {updatedSale.Residence} , @PostalCode = {updatedSale.PostalCode} , @CreditCardNumber = {updatedSale.CreditCardNumber}");

                if (sale > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //_dbPharmacyContext.Entry(sale).State = EntityState.Modified;
                //await _dbPharmacyContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "the sale you are specified not found");
                return false;
            }
        }

        public async Task<bool> DeleteSale(int id)
        {
            var sale = await _dbPharmacyContext.Sales.FirstOrDefaultAsync(s => s.Id == id);

            if (sale != null)
            {
                try
                {
                    sale.InvoiceStatusId = 2;
                    _dbPharmacyContext.Sales.Entry(sale).State = EntityState.Modified;
                    await _dbPharmacyContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while deleting the sale");
                    return false;
                }
            }
            return false;
        }
    }
}
