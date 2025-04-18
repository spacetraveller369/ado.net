﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dapper.Models;

public partial class Order
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public int? IdUser { get; set; }

    [ForeignKey("Product")]
    public int? IdProduct { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
