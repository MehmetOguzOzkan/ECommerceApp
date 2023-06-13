using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.DTOs
{
    public class UpdateAddressDTO
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
    }
}
