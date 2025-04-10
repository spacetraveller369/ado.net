using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repos.Models;

public partial class Review
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Required to fill in!")]
    [StringLength(4000)]
    public string? Text { get; set; }

    public virtual ICollection<Product> IdProducts { get; set; } = new List<Product>();
}
