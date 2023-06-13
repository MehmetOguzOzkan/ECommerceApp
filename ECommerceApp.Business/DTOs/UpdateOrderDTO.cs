using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.DTOs
{
    public class UpdateOrderDTO
    {
        public int CartId { get; set; }
        public int AddressId { get; set; }
    }
}
