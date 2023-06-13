using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommerceApp.Data.Entities.User;

namespace ECommerceApp.Business.DTOs
{
    public class GetUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }


        public DateTime? BirthDate { get; set; }
        public GenderType? Gender { get; set; }
    }
}
