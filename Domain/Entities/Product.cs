using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string Code { get; set; }
        public void IncreaseStock(int quantity)
        {
            if (quantity <= 0) throw new Exception("Cantidad inválida");
            Stock += quantity;
        }

        public void DecreaseStock(int quantity)
        {
            if (quantity <= 0) throw new Exception("Cantidad inválida");
            if (Stock - quantity < 0)
                throw new Exception("Stock no puede ser negativo");

            Stock -= quantity;
        }
    }
}
