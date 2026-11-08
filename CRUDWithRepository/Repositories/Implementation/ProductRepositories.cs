using CRUDWithRepository.DAL;
using CRUDWithRepository.Models;
using Fluent.Infrastructure.FluentModel;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithRepository.Repositories.Implementation
{
    public class ProductRepositories : IProductRepositories
    {
        public readonly MyAppDbContext _context;

        public ProductRepositories(MyAppDbContext myAppDbContext)
        {
            _context = myAppDbContext;
        }
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                throw new Exception("Product not found");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync<Product>();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
