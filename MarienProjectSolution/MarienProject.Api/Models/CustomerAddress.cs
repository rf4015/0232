using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class CustomerAddress
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int MunicipalityId { get; set; }

    public string Address { get; set; }

    public string Residence { get; set; }

    public string PostalCode { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual Municipality Municipality { get; set; }
}
