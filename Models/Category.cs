using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dapper.Models;

public partial class Category
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Required to fill in!")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
