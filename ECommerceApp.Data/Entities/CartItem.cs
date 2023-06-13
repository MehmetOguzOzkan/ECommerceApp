using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    [Table("CartItems")]
    public class CartItem : BaseEntity<int>
    {
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }
        [NotMapped]
        public double? SubTotal => Product?.Price * Quantity;
    }
}
