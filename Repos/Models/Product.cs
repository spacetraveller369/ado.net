using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repos.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Required to fill in!")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [ForeignKey("Category")]
    public int IdCategory { get; set; }

    [Required(ErrorMessage = "Required to fill in!")]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Required to fill in!")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Required to fill in!")]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
    public double PriceDelivery { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> IdReviews { get; set; } = new List<Review>();
}
