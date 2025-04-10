using System;
using System.Collections.Generic;
<<<<<<< HEAD

namespace Database_first.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdCategory { get; set; }

    public double? Price { get; set; }

    public int? Quantity { get; set; }

    public int? IdProducer { get; set; }

    public int? IdMeasurement { get; set; }

    public int? IdMarkup { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Discount? IdMarkupNavigation { get; set; }

    public virtual Measurement? IdMeasurementNavigation { get; set; }

    public virtual Producer? IdProducerNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
=======
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dapper.Models;

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
>>>>>>> 7f72fab8e5ce4a1291c6173b3cd3bd9556cdbecb
}
