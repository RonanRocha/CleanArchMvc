using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
     
        public string Name { get; private set; }
        public ICollection<Product> Products { get;  set; }

        public Category(string name) 
        { 
            ValidateDomain(name);
            Name = name;
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id number");
            ValidateDomain(name);

            Id = id;
            Name = name;
        }


        public void Update(string name)
        {
            ValidateDomain(name);
            name = Name;
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(name),  "Invalid name");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, to short, minimum 3 characters");
        }
    }
}
