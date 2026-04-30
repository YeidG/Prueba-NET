using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs.Request
{
    public class CreateProductDto
    {
       [Required(ErrorMessage = "El código es obligatorio")]
        public string Code { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Name { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }
    }
}
