using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MarienProject.Api.Models;

public partial class CustomerAddress
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int MunicipalityId { get; set; }

    public string Address { get; set; } = null!;

    public string Residence { get; set; } = null!;

    public string? PostalCode { get; set; }
    [JsonIgnore]
    public virtual Customer Customer { get; set; } = null!;
    [JsonIgnore]
    public virtual Municipality Municipality { get; set; } = null!;
}
