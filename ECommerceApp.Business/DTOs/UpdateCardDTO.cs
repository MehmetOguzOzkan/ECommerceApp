using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.DTOs
{
    public class UpdateCardDTO
    {
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.CreditCard)]
        public string Number { get; set; }

        public int UserId { get; set; }
    }
}
