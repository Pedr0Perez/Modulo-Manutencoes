using System.ComponentModel.DataAnnotations;

namespace ModuloManutencoes.Dtos.LoginDtos
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O endereço de e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; } = null!;
    }
}
