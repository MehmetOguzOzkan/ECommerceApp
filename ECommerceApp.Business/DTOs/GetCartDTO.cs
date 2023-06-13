using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.DTOs
{
    public class GetCartDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CartItem> Items { get; set; }
        [MaxLength(200)]
        public string Note { get; set; }
    }
}
