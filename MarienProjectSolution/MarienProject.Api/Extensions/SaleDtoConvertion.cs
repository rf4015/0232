using MarienProject.Api.Models;
using MarienProject.Models.Dtos;

namespace MarienProject.Api.Extensions
{
    public static class SaleDtoConvertion
    {
        public static IEnumerable<SaleDto> ConvertToDto(this IEnumerable<Sale> saleModel) 
        {
            return (from sale in saleModel
                    select new SaleDto
                    {
                        Id = sale.Id,
                        CustomerId = sale.CustomerId,
                        InvoiceStatusId = sale.InvoiceStatusId,
                        DeliveryTypeId = sale.DeliveryTypeId,
                        EmployeeId = sale.EmployeeId,
                        DeliveryEmployeeId = sale.DeliveryEmployeeId,
                        ShippingDate = sale.ShippingDate,
                        MunicipalityId = sale.MunicipalityId,
                        OrderDate = sale.OrderDate,
                        DeliveryDate = sale.DeliveryDate,
                        Address = sale.Address,
                        Residence = sale.Residence,
                        PostalCode = sale.PostalCode,
                        CreditCardNumber = sale.CreditCardNumber
                    });
        }
        public static SaleDto ConvertToDto(this Sale sale)
        {
            return new SaleDto() 
            {
                Id = sale.Id,
                CustomerId = sale.CustomerId,
                InvoiceStatusId = sale.InvoiceStatusId,
                DeliveryTypeId = sale.DeliveryTypeId,
                EmployeeId = sale.EmployeeId,
                MunicipalityId = sale.MunicipalityId,
                DeliveryEmployeeId = sale.DeliveryEmployeeId,
                ShippingDate = sale.ShippingDate,
                OrderDate = sale.OrderDate,
                DeliveryDate = sale.DeliveryDate,
                Address = sale.Address,
                Residence = sale.Residence,
                PostalCode = sale.PostalCode,
                CreditCardNumber = sale.CreditCardNumber
            };

        }
    }
}
