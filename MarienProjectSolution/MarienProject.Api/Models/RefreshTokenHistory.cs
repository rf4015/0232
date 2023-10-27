using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class RefreshTokenHistory
{
    public int HistorialTokenId { get; set; }

    public int? UserId { get; set; }

    public string? Token { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual UserProfile? User { get; set; }
}
