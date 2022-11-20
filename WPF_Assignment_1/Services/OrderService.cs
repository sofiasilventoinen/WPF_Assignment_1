using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using WPF_Assignment_1.Data;
using WPF_Assignment_1.Models;
using WPF_Assignment_1.Models.Entities;
using WPF_Assignment_1.Service;

namespace WPF_Assignment_1.Services
{
    public class OrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }


        //denna metod skapar en order kopplad till kund och produkt.
        public async Task<ActionResult> CreateOrderAsync(OrderRequest orderRequest)
        {
            try
            {
                var orderentity = new OrderEntity()
                {
                    OrderDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(30),
                    CustomerId = orderRequest.CustomerId,
                };

                _context.Orders.Add(orderentity);
                await _context.SaveChangesAsync();

                foreach (var item in orderRequest.Products)

                    orderentity.Products.Add(new ProductEntity { Id = item.Id });

                _context.Add(orderentity);
                await _context.SaveChangesAsync();
                return new OkResult();

            }
            catch { return new BadRequestResult(); } 


        }
    }
}
