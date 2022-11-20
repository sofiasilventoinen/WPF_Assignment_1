using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assignment_1.Models.Entities
{
    public class CustomerEntity
    {
        public CustomerEntity()
        {

        }
        public CustomerEntity(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ICollection<OrderEntity> order { get; set; }
    }
}
