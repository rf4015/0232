using MarienProject.Api.Models;
using MarienProject.Models.Dtos;

namespace MarienProject.Api.Extensions
{
    public static class SaleDetailDtoConvertion
    {
        public static IEnumerable<SaleDetailDto> ConvertToDto(this IEnumerable<SaleDetail> saleModel)
        {
            return (from sale in saleModel
                    select new SaleDetailDto
                    {
                        Id = sale.Id,
                        SaleId = sale.SaleId,
                        MedicationInStockId = sale.MedicationInStockId,
                        Price = sale.Price,
                        Quantity = sale.Quantity,
                        Discount = sale.Discount,
                        Tax = sale.Tax,
                        Subtotal = sale.Subtotal,
                        Total = sale.Total
                    }).ToList();
        }
        public static SaleDetailDto ConvertToDto(this SaleDetail sale)
        {
            return new SaleDetailDto()
            {
                Id = sale.Id,
                SaleId = sale.SaleId,
                MedicationInStockId = sale.MedicationInStockId,
                Price = sale.Price,
                Quantity = sale.Quantity,
                Discount = sale.Discount,
                Tax = sale.Tax,
                Subtotal = sale.Subtotal,
                Total = sale.Total
            };

        }
    }
}
