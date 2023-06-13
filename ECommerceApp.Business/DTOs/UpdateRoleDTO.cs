using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.DTOs
{
    public class UpdateRoleDTO
    {
        [Required(ErrorMessage = "Required Field"), MaxLength(30)]
        public string Name { get; set; }
    }
}
