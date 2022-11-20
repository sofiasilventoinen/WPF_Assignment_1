using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Assignment_1.Data;
using WPF_Assignment_1.Models;
using WPF_Assignment_1.Models.Entities;

namespace WPF_Assignment_1.Service
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        //skapa
        public async Task<ActionResult>CreateAsync(ProductRequest req)
        {
            _context.Add(new ProductEntity(req.Name, req.Description, req.Price));    
            await _context.SaveChangesAsync();
            return new OkResult();
        }


        //hämta alla produkter
        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // hämta en specifik produkt baserat på id  
        public async Task<ProductEntity> GetAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        //updatera ett objekt
        public async Task UpdateAsync(ProductEntity product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync(); 
        }

        //hitta produkten, ta bort den och spara ändringarna
        public async Task DeleteAsync(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();
        }
    }
}
