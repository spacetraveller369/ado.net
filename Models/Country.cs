using System;
using System.Collections.Generic;

namespace Database_first.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
