using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class MedicationLaboratory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool? State { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public virtual ICollection<MedicationDetail> MedicationDetails { get; set; } = new List<MedicationDetail>();
}
