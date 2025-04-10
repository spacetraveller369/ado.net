using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repos.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Required to fill in!")]
    [StringLength(50)]
    [Column("name")]
    public string Name { get; set; } = null!;

    [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
    public int Age { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
