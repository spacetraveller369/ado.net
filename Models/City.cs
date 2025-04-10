using System;
using System.Collections.Generic;

namespace Database_first.Models;

public partial class City
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdRegion { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Region? IdRegionNavigation { get; set; }
}
