using System.ComponentModel.DataAnnotations;

namespace ApiEstudo.DTOs
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, ErrorMessage = "O nome deve ter até 80 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(300, ErrorMessage = "A descrição deve ter até 300 caracteres.")]
        public string? Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A URL da imagem é obrigatória.")]
        [StringLength(300, ErrorMessage = "A URL da imagem deve ter até 300 caracteres.")]
        public string? ImagemUrl { get; set; }

        [Required(ErrorMessage = "O ID da categoria é obrigatório.")]
        public int CategoriaId { get; set; }
    }
}
