using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Models
{
    public class ProductCategoryView
    {
        public int Id { get; set; }
        public string product_name { get; set; } = null!;
        public string category_name { get; set; } = null!;
    }
}
