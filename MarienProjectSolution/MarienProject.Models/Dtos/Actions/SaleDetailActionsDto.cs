using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarienProject.Models.Dtos.Actions
{
    public class SaleDetailActionsDto
    {
        //public int SaleId { get; set; }

        public int MedicationInStockId { get; set; }

        //public double Price { get; set; }

        public int Quantity { get; set; }

        public double Discount { get; set; }

        public double Tax { get; set; }

        //public double Subtotal { get; set; }

        //public double Total { get; set; }
    }
}
