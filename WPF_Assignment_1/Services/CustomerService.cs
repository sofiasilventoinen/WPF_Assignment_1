using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Assignment_1.Data;
using WPF_Assignment_1.Models;
using WPF_Assignment_1.Models.Entities;

namespace WPF_Assignment_1.Services
{
    public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        //skapa
        public async Task Create(CustomerRequest req)
        {
            var customerEntity = new CustomerEntity
            {
                Name = req.Name,
                Email = req.Email
            };
            _context.Add(customerEntity);
            await _context.SaveChangesAsync();
        }

        //public async Task CreateAsync(CustomerRequest req)
        //{
        //    _context.Add(new CustomerEntity(req.Name, req.Email));
        //    await _context.SaveChangesAsync();
        //}

        //visa alla
        public async Task<List<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        //public async Task <IEnumerable<CustomerRequest>>GetAll()
        //{
        //    var customers = new List<CustomerRequest>();
        //    foreach (var customer in await _context.Customers.ToListAsync())
        //        customers.Add(new CustomerRequest { Id = customer.Id, Name = customer.Name, Email = customer.Email });
        //    return customers;
        //}

        // hämta en specifik kund baserat på id  
        public async Task<CustomerEntity> GetAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        //public async Task<CustomerEntity> Get(int id)
        //{
        //    var customerEntity = await _context.Customers.FindAsync(id);
        //    if (customerEntity != null)
        //        return new CustomerEntity { Id = customerEntity.Id, Name = customerEntity.Name, Email = customerEntity.Email };
        //    return null!;
        //}

        //updatera 
        public async Task UpdateAsync(CustomerEntity customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //hitta kund, ta bort den och spara ändringarna
        public async Task DeleteAsync(int id)
        {
            var customerentity = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customerentity);
            await _context.SaveChangesAsync();
        }
    }
}
