using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Municipality> Municipalities { get; set; } = new List<Municipality>();
}
