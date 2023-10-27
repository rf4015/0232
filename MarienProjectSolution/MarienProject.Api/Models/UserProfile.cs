using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class UserProfile
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPassaword { get; set; } = null!;

    public byte[]? ProfileImage { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<RefreshTokenHistory> RefreshTokenHistories { get; set; } = new List<RefreshTokenHistory>();
}
