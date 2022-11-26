using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    // sealed não pode ser herdada
    public sealed class Product : Base
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        // 1:1 de Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        // Construtores
        public Product(string name, string description,
            decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description,
            decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0,
                "Id inválido");
            this.Id = id;
            ValidateDomain(name, description, price, stock, image);
        }


        // Setter
        public void Update(string name, string description,
            decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            this.CategoryId = categoryId;
        }


        // Validações
        private void ValidateDomain(string name, string description,
            decimal price, int stock, string image)
        {
            // name
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido. Nome é obrigatório");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome inválido. Minimo de 3 caracteres");

            // description
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Descrição inválida. Nome é obrigatório");

            DomainExceptionValidation.When(description.Length < 5,
                "Descrição inválida. Minimo de 5 caracteres");

            // price
            DomainExceptionValidation.When(price < 0,
                "Preço inválido");

            // stock
            DomainExceptionValidation.When(stock < 0,
                "Estoque inválido");

            // image
            DomainExceptionValidation.When(image.Length > 250,
                "Nome da imagem muito longo, máximo de 250");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }
    }
}
