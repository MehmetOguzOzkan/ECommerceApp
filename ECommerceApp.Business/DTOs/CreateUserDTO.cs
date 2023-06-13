using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommerceApp.Data.Entities.User;

namespace ECommerceApp.Business.DTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Required Field")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        public DateTime? BirthDate { get; set; }
        public GenderType? Gender { get; set; }

        public int RoleId { get; set; }
    }
}
