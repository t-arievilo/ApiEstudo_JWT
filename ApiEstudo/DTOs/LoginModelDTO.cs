using System.ComponentModel.DataAnnotations;

namespace ApiEstudo.DTOs
{
    public class LoginModelDTO
    {
        [Required(ErrorMessage = "Username é obrigatório")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password é obrigatório")]
        public string? Password { get; set; }
    }
}
