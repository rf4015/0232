using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarienProject.Models.Dtos.Actions
{
    public class SaleActionsDto
    {
        public int CustomerId { get; set; }

        public int InvoiceStatusId { get; set; }

        public int DeliveryTypeId { get; set; }

        public int? EmployeeId { get; set; }

        public int? DeliveryEmployeeId { get; set; }

        public int? MunicipalityId { get; set; }

        //public DateTime? OrderDate { get; set; }

        //public DateTime? ShippingDate { get; set; }

        //public DateTime? DeliveryDate { get; set; }

        public string? Address { get; set; }

        public string? Residence { get; set; }

        public string? PostalCode { get; set; }

        public string? CreditCardNumber { get; set; }
    }
}
