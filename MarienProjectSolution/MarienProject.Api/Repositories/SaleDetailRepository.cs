using MarienProject.Api.Models;
using MarienProject.Api.Repositories.Contracts;
using MarienProject.Models.Dtos.Actions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;

namespace MarienProject.Api.Repositories
{
    public class SaleDetailRepository : ISaleDetailRepository
    {
        private readonly MarienPharmacyContext _dbPharmacyContext;
        private readonly ILogger<SaleDetailRepository> _logger;

        public SaleDetailRepository(MarienPharmacyContext dbPharmacyContext, ILogger<SaleDetailRepository> logger)
        {
            _dbPharmacyContext = dbPharmacyContext;
            _logger = logger;
        }
        public async Task<bool> CreateSaleDetail(SaleDetail saleDetail)
        {
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                var result = await _dbPharmacyContext.Database.ExecuteSqlRawAsync ($"uspCreateSaleDetail {saleDetail.MedicationInStockId}, {saleDetail.Quantity}, {saleDetail.Discount.ToString(culture)}, {saleDetail.Tax.ToString(culture)}");

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //_dbPharmacyContext.SaleDetails.Add(saleDetail);
                //await _dbPharmacyContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the SaleDetail: ", ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteSaleDetail(int id)
        {
            var sale = await _dbPharmacyContext.Database.ExecuteSqlRawAsync($"EXECUTE uspDeleteSaleDetail @IdSaleDetail = {id}");

            if (sale > 0)
            {
                try
                {
                    ////Cambiar el id segun el stado de la factura en la tabla...
                    //sale.Sale.InvoiceStatusId = 2;
                    //_dbPharmacyContext.SaleDetails.Entry(sale).State = EntityState.Modified;
                    //await _dbPharmacyContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while deleting the sale");
                    return false;
                }
            }
            else
            {
                return false;   
            }
        }

        public async Task<IEnumerable<SaleDetail>> GetAllSalesDetails()
        {
            try
            {
                var sales = await _dbPharmacyContext.SaleDetails
                                .Include(s => s.Sale).Where(s => s.Sale.InvoiceStatusId != 3).ToArrayAsync();
                return sales;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all SalesDetails");
                return null;
            }
        }

        public async  Task<SaleDetail> GetSaleDetailsById(int id)
        {
            try
            {
                var sale = await _dbPharmacyContext.SaleDetails.FirstOrDefaultAsync(s => s.Id == id);

                if (sale == null)
                {
                    throw new Exception("SaleDetail not found");
                }
                return sale;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting saleDetail");
                return null;
            }
        }

        public async Task<bool> UpdateSaleDetail(int id, SaleDetail updatedSaleDetail)
        {
            try
            {
                CultureInfo culture = new CultureInfo("en-US");

                var saleDetail = await _dbPharmacyContext.Database.ExecuteSqlRawAsync($"uspUpdateSaleDetail @Id_SaleDetail = {id}, @IdMedicationInStock = {updatedSaleDetail.MedicationInStockId}, @Quantity = {updatedSaleDetail.Quantity}, @Discount = {updatedSaleDetail.Discount.ToString(culture)}, @Tax = {updatedSaleDetail.Tax.ToString(culture)}");

                if(saleDetail > 0)
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
                _logger.LogError(ex, "An error ocurred while getting SaleDetail or was not found");
                return false;
            }
            
        }
    }
}
