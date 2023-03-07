using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo de 3")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 100")]
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}
