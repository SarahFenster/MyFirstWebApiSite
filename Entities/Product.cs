using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyFirstWebApiSite;

public partial class Product
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public double? Price { get; set; }
    
    public virtual Category? Category { get; set; }
    
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
