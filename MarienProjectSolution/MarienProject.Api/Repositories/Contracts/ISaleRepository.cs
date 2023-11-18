using MarienProject.Api.Models;

namespace MarienProject.Api.Repositories.Contracts
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllSales();
        Task<Sale> GetSaleById(int id);
        Task<bool> CreateSale(Sale sale);
        Task<bool> UpdateSale(int id, Sale updatedSale);
        Task<bool> DeleteSale(int id);
    }
}
