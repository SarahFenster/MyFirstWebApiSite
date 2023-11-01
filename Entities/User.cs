using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int Id { get; set; }
    [EmailAddress(ErrorMessage = "The UserName field must have a email address format")]//how?
    public string? UserName { get; set; }
    [StringLength(10, ErrorMessage = "Password length can't be more than 10, choose a different password")]//how?
    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
