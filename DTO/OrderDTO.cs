using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public double? OrderSum { get; set; }

        public DateTime? OrderDate { get; set; }

        public int OrderItemId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        //public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
