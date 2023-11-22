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
   
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    [JsonIgnore]
    public virtual User? User { get; set; }


//    {
//  "id": 0,
//  "userId": 3,
//  "orderSum": 325.9,
//  "orderDate": "2023-11-21T15:49:31.788Z",
//"orderItems":[
//{"productId":4, "quantity":3},
//{"productId":13, "quantity":1},
//{ "productId":7, "quantity":1}
//]
//}
    
}
