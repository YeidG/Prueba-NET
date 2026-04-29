using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Product> Create(Product product)
        {
            return await _repo.Add(product);
        }

        public async Task<List<Product>> GetAll(int page, int size)
        {
            return await _repo.GetAll(page, size);
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await _repo.GetById(id);
            if (product == null) throw new Exception("No encontrado");
            return product;
        }

        public async Task UpdateStock(Guid id, int quantity, bool increase)
        {
            var product = await _repo.GetById(id);
            if (product == null) throw new Exception("No encontrado");

            if (increase)
                product.IncreaseStock(quantity);
            else
                product.DecreaseStock(quantity);

            await _repo.Update(product);
        }
    }
}
