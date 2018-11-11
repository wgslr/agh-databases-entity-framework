using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Geisler
{
    class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set;}

        [ForeignKey("Customer")]
        [Required]
        public String CustomerName { get; set; }
        public virtual Customer Customer { get; set; }

        public int Quantity { get; set; }
    }
}
