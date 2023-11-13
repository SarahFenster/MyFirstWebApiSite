using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyFirstWebApiSite;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public double? OrderSum { get; set; }

    public DateTime? OrderDate { get; set; }
    [JsonIgnore]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User? User { get; set; }
}
