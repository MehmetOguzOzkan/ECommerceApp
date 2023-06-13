using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    [Table("Roles")]
    public class Role : BaseEntity<int>
    {
        [Required(ErrorMessage = "Required Field"), MaxLength(30)]
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
