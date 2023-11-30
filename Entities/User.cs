using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApiSite;

public partial class User
{
    public int Id { get; set; }
    [EmailAddress(ErrorMessage ="User Name must be in email format")]
    public string UserName { get; set; }

    public string Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
