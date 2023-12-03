using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserLoginDTO
    {
        [StringLength(20, ErrorMessage ="Password length can't be more than 20")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
