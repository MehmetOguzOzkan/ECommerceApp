using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    [Table("Addresses")]
    public class Address : BaseEntity<int>
    {
        [Required(ErrorMessage = "Required Field")]
        public string City { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string District { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Neighborhood { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Required Field")]
        public string Number { get; set; }
        [DataType(DataType.PostalCode)]
        public int? PostalCode { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }


    }
}
