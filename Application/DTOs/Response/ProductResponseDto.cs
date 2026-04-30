using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Response
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
