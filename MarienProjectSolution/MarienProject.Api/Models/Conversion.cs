using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Conversion
{
    public int Id { get; set; }

    public int UnitOfMeasurementId { get; set; }

    public string Description { get; set; }

    public int? Value { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual UnitOfMeasurement UnitOfMeasurement { get; set; }
}
