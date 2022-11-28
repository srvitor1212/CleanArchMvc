using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTeste1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, "prod image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }


        // Id
        [Fact]
        public void CreateProduct_IdNegative_ExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product description", 9.99m, 99, "prod image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Id inválido");
        }


        // Name
        [Fact]
        public void CreateProduct_ShortName_ExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product description", 9.99m, 99, "prod image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido. Minimo de 3 caracteres");
        }

        [Fact]
        public void CreateProduct_EmptyName_ExceptionEmptyName()
        {
            Action action = () => new Product(1, "", "Product description", 9.99m, 99, "prod image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido. Nome é obrigatório");
        }

        [Fact]
        public void CreateProduct_NullName_ExceptionNullName()
        {
            Action action = () => new Product(1, null, "Product description", 9.99m, 99, "prod image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido. Nome é obrigatório");
        }


        // description
        [Fact]
        public void CreateProduct_ShortDescription()
        {
            Action action = () => new Product(1, "Product Name", "des", 9.99m, 99, "prod image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida. Minimo de 5 caracteres");
        }

        [Fact]
        public void CreateProduct_EmptyDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "prod image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida. Descrição é obrigatória");
        }

        [Fact]
        public void CreateProduct_NullDescription()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "prod image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida. Descrição é obrigatória");
        }

        // price
        [Fact]
        public void CreateProduct_NegativePrice()
        {
            Action action = () => new Product(1, "Product Name", "Product description", -9.99m, 99, "prod image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Preço inválido");
        }

        // stock
        [Theory]
        [InlineData(-5)]
        public void CreateProduct_NegativeStock(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, value, "prod image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Estoque inválido");
        }

        // image
        [Fact]
        public void CreateProduct_LengthTooLong()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, "prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...prod image too long...");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Nome da imagem muito longo, máximo de 250");
        }

        [Fact]
        public void CreateProduct_NullImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

    }
}
