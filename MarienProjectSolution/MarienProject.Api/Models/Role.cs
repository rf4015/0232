﻿using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
