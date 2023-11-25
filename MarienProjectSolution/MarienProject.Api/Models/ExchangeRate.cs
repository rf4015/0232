using System;
using System.Collections.Generic;

namespace MarienProject.Api.Models;

public partial class ExchangeRate
{
    public int CurrencyId { get; set; }

    public DateTime? Date { get; set; }

    public double BuyingRate { get; set; }

    public double SellingRate { get; set; }

    public virtual Currency Currency { get; set; }
}
