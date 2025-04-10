using System;
using System.Collections.Generic;

namespace Database_first.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdAddress { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Address? IdAddressNavigation { get; set; }
}
