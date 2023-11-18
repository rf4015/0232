using MarienProject.Api.Models;
using MarienProject.Models.Dtos.Actions;

namespace MarienProject.Api.Repositories.Contracts
{
    public interface ISaleDetailRepository
    {
        Task<IEnumerable<SaleDetail>> GetAllSalesDetails();
        Task<SaleDetail> GetSaleDetailsById(int id);
        Task<bool> CreateSaleDetail(SaleDetail saleDetail);
        Task<bool> UpdateSaleDetail(int id, SaleDetail updatedSaleDetail);
        Task<bool> DeleteSaleDetail(int id);
    }
}
