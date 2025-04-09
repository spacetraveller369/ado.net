using System;
using System.Collections.Generic;

namespace Dapper.Models;

public partial class ProductCategoryView
{
    public int Id { get; set; }

    public string product_name { get; set; } = null!;

    public string category_name { get; set; } = null!;
}
