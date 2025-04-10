using System;
using System.Collections.Generic;
<<<<<<< HEAD

namespace Database_first.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }
=======
using System.ComponentModel.DataAnnotations;

namespace Dapper.Models;

public partial class Category
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Required to fill in!")]
    [StringLength(50)]
    public string Name { get; set; } = null!;
>>>>>>> 7f72fab8e5ce4a1291c6173b3cd3bd9556cdbecb

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
