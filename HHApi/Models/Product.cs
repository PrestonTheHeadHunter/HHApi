

using System;

namespace HHApi.Models
{
    public class Product : IProduct
    {
        
        public Product( int id, string description, decimal price)
        {
            Id = id;
            Description = description;
            Price = price;
        }
        public Product(string description, decimal price)
        {
            Description = description;
            Price = price;

            Id = GenerateNewId();
        }
        public Product()
        {
            Id = GenerateNewId();
        }
        
        private int GenerateNewId()
        {
            return new Random().Next(0, 1000000);
        }
        public double Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

    }
}