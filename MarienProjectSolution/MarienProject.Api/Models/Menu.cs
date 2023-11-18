using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string MenuName { get; set; } = null!;

    public int? IdMenuFather { get; set; }

    public int IdRole { get; set; }

    public virtual Menu? IdMenuFatherNavigation { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Menu> InverseIdMenuFatherNavigation { get; set; } = new List<Menu>();
}
