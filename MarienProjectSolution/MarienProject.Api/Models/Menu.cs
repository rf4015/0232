using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string MenuNombre { get; set; }

    public int Position { get; set; }

    public string UrlImg { get; set; }

    public int? MenuFatherId { get; set; }

    public int RolId { get; set; }

    public virtual ICollection<Menu> InverseMenuFather { get; set; } = new List<Menu>();

    public virtual Menu MenuFather { get; set; }

    public virtual Role Rol { get; set; }
}
