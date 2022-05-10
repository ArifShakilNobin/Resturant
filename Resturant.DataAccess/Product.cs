using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DataAccess
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }

        public double price { get; set; }
        public string? Description { get; set; }
    }
}
