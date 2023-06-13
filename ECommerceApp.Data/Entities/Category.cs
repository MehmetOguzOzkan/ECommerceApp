using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    [Category("Categories")]
    public class Category : BaseEntity<int>
    {
        [Required(ErrorMessage = "Required Field")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
