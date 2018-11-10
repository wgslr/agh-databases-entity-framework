using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geisler
{
    class Customer
    {
        [Key]
        public String CompanyName { get; set; }
        public String Description { get; set; }
    }
}
