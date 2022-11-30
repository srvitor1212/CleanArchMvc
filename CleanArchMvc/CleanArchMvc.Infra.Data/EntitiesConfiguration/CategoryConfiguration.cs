using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Define como PK da tabela
            builder.HasKey(x => x.Id);

            // Define o tamanho da coluna e não pode ser nula
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            // Inclui os registros na tabela ao fazer a migração
            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2, "Eletrônicos"),
                new Category(3, "Acessórios")
            );
        }
    }
}
