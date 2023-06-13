using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.DTOs
{
    public class UpdateCartItemDTO
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
