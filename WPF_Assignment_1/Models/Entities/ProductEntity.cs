using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assignment_1.Models.Entities
{
    public class ProductEntity
    {

        public ProductEntity()
        {

        }
        public ProductEntity(string name, string? description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public int Id { get; set; } 

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        
        public ICollection<OrderEntity> ?Order { get; set; }
        
    }
}
