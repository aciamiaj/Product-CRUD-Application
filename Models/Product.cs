using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public partial class Product
    {
        [Key]
        [Required(ErrorMessage = "Product ID cannot be empty.")]
        [Remote("CheckID", "Product")]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Please enter a product name.")]
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        [Range(0.01, 1000000.0,
            ErrorMessage = "Price must be greater than zero.")]
        [Required(ErrorMessage = "Please enter a product price.")]
        public decimal ProductPrice { get; set; }
    }
}
