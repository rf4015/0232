using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string MenuName { get; set; }

    public int Positión { get; set; }

    public string UrlImg { get; set; }

    public int? MenuFatherId { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Menu> InverseMenuFather { get; set; } = new List<Menu>();

    public virtual Menu MenuFather { get; set; }

    public virtual Role Role { get; set; }
}
