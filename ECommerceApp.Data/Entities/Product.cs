using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    [Table("Products")]
    public class Product : BaseEntity<int>
    {
        [Required(ErrorMessage = "Required Field")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [Range(0.1, double.MaxValue)]
        public double Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
