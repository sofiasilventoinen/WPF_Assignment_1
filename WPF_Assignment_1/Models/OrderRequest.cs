using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Assignment_1.Models.Entities;

namespace WPF_Assignment_1.Models
{
    public class OrderRequest
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
    }
}
