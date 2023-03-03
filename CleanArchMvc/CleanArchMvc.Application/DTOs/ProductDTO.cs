using CleanArchMvc.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Descrição é obrigatória")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Estoque é obrigatório")]
        [Range(1, 9999)]
        [DisplayName("Estoque")]
        public int Stock { get; set; }


        [Required(ErrorMessage = "Imagem do produto obrigatória")]
        [MaxLength(250)]
        [DisplayName("Imagem do produto")]
        public string Image { get; set; }


        [DisplayName("Categorias")]
        public int CategoryId { get; set; }

    }
}
