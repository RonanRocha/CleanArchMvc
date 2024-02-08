using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                  .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_WithInvalidValidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Invalid id number");
        }

        [Fact]
        public void CreateCategory_WithInvalidValidParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Category(2, null);
            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Invalid name");
        }

        [Fact]
        public void CreateCategory_WithInvalidValidParameters_DomainExceptionInvalidNameLenght()
        {
            Action action = () => new Category(1, "ed");
            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Invalid name, to short, minimum 3 characters");
        }

        [Fact]
        public void UpdateCategory_WithInvalidValidParameters_DomainExceptionInvalidNameLenght()
        {

            var category = new Category(1, "edasdasd");

            Action action = () => category.Update("es");
            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Invalid name, to short, minimum 3 characters");
        }
    }
}