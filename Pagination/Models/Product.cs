using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Models
{
    [Table("product")]
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Category { get; set; }
        public int Price { get; set; }
    }
}
