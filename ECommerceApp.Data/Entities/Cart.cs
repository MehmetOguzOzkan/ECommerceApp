using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    [Table("Carts")]
    public class Cart : BaseEntity<int>
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public List<CartItem> Items { get; set;}
        [MaxLength(200)]
        public string Note { get; set; }
        [NotMapped]
        public double? Total => Items?.Sum(x=>x.SubTotal);
    }
}
