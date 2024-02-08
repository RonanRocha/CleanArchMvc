using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
 
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get;  set; }
        public Category  Category{ get;  set; }


        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image); 

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }



        public Product(int id, string name, string description, decimal price, int stock, string image)
        {

            DomainExceptionValidation.When(id < 0, "Invalid id, is required");

            ValidateDomain(name, description, price, stock, image);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name,description,price, stock,image);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(name),
                "Invalid name, is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, to short, minimum 3 characters");

            DomainExceptionValidation.When(image.Length > 250,
                "Invalid image, to large, maximun 250 characters");

            DomainExceptionValidation.When(description.Length < 3,
                "Invalid name, to short, minimum 3 characters");

            DomainExceptionValidation.When(String.IsNullOrEmpty(description),
                "Invalid description, is required");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, to short, minimum 5 characters");

            DomainExceptionValidation.When(price < 0,
                "Invalid price, is negative, not permited negative numbers");

            DomainExceptionValidation.When(stock < 0,
                "Invalid stock, is negative, not permited negative numbers");
        }
    }
}
