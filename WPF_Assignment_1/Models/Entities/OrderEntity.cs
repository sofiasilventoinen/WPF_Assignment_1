using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assignment_1.Models.Entities
{


    public class OrderEntity
    {
        

        public int id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public string ?CustomerName { get; set; }
        public int CustomerId { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
        public CustomerEntity customer { get; set; } = null!;
    }
}
