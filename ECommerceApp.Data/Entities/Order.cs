using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    [Table("Orders")]
    public class Order : BaseEntity<int>
    {
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}
