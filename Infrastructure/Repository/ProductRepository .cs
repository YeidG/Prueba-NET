using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetAll(int page, int size)
        {
            return await _context.Products
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await GetById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
