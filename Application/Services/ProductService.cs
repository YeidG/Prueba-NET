using Application.DTOs.Request;
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
            var existing = await _repo.GetByCode(product.Code);

            if (existing != null)
                throw new Exception("El código del producto ya existe");

            return await _repo.Add(product);
        }

        public async Task<List<Product>> GetAll(int page, int size)
        {
            return await _repo.GetAll(page, size);
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _repo.GetById(id);
            if (product == null) throw new Exception("Producto No encontrado");
            return product;
        }

        public async Task<Product> GetByCode(String code)
        {
            var product = await _repo.GetByCode(code);
            if (product == null) throw new Exception("Producto No encontrado");
            return product;
        }

        public async Task UpdateStock(int id, int quantity)
        {
            var product = await _repo.GetById(id);
            if (product == null) throw new Exception("Producto No encontrado");

         
            if (quantity > 0)
            {
                product.IncreaseStock(quantity);
            }
            else
            {
                product.DecreaseStock(Math.Abs(quantity));
            }

            await _repo.Update(product);
        }


        public async Task<Product> Update(int id, UpdateProductDto dto)
        {
            var product = await _repo.GetById(id);

            if (product == null)
                throw new Exception("Producto no encontrado");

            
            var existing = await _repo.GetByCode(dto.Code);
            if (existing != null && existing.Id != id)
                throw new Exception("El código ya existe");

            product.Code = dto.Code;
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            await _repo.Update(product);

            return product;
        }
    }
}
