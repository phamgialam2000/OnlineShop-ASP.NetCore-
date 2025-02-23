using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
