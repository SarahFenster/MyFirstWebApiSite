using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [EmailAddress(ErrorMessage = "User Name must be in email format")]
        public string UserName { get; set; }
        [StringLength(20, ErrorMessage = "Password length can't be more than 20")]
        public string Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
