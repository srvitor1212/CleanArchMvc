using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    // sealed não pode ser herdada
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
                
        // 1:N de Product
        public ICollection<Product> Products { get; private set; }


        public Category(string name)
        {
            ValidadeDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0,
                "Id inválido");

            ValidadeDomain(name);

            this.Id = id;
        }


        private void ValidadeDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido. Nome é obrigatório");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome inválido. Minimo de 3 caracteres");

            this.Name = name;
        }
    }
}
