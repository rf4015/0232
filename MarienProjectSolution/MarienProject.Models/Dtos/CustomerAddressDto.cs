using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarienProject.Models.Dtos
{
    public class CustomerAddressDto
    {
        public int Id { get; set; }

        public int MunicipalityId { get; set; }

        public string Address { get; set; } = null!;

        public string Residence { get; set; } = null!;

        public string? PostalCode { get; set; }
    }
}
