using System.ComponentModel.DataAnnotations;

namespace ApiEstudo.DTOs
{
    public class RegisterModelDTO
    {
        [Required(ErrorMessage = "Username é obrigatório")]
        public string? UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password é obrigatório")]
        public string? Password { get; set; }
    }
}
