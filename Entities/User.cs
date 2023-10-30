using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public int UserId { get; set; }
        [EmailAddress(ErrorMessage = "The UserName field must have a email address format")]
        public string UserName { get; set; }
        [StringLength(10, ErrorMessage = "Password length can't be more than 10, choose a different password")]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}