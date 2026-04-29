using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Add(Product product);
        Task<Product> GetById(Guid id);
        Task<List<Product>> GetAll(int page, int size);
        Task Update(Product product);
        Task Delete(Guid id);
    }
}
