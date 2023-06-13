using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    [Table("Cards")]
    public class Card : BaseEntity<int>
    {
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.CreditCard)]
        public string Number { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
