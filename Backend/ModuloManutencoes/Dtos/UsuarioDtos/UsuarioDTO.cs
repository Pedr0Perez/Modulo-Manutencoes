using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ModuloManutencoes.Dtos.UsuarioDtos
{
    public class UsuarioDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "O primeiro nome é obrigatório.")]
        [MaxLength(25, ErrorMessage = "O primeiro nome não pode ultrapassar 25 caracteres.")]
        public string PrimeiroNome { get; set; } = null!;
        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O sobrenome não pode ultrapassar 50 caracteres.")]
        public string Sobrenome { get; set; } = null!;
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail fornecido é inválido.")]
        [MaxLength(320, ErrorMessage = "O e-mail não pode ultrapassar 320 caracteres.")]
        public string Email { get; set; } = null!;
        [MaxLength(320, ErrorMessage = "O e-mail 2 não pode ultrapassar 320 caracteres.")]
        [EmailAddress(ErrorMessage = "O e-mail 2 fornecido é inválido.")]
        public string? Email2 { get; set; }
        [MaxLength(20, ErrorMessage = "A senha não pode ultrapassar 20 caracteres.")]
        public string Senha { get; set; } = null!;
        public DateTime? DataNascimento { get; set; }
        [MaxLength(1, ErrorMessage = "O tipo de gênero só suporta 1 caractere.")]
        public string Genero { get; set; } = null!;
        [MaxLength(64, ErrorMessage = "O país não pode ultrapassar 64 caracteres.")]
        public string? Pais { get; set; }
        [MaxLength(64, ErrorMessage = "A cidade não pode ultrapassar 64 caracteres.")]
        public string? Cidade { get; set; }
        [MaxLength(64, ErrorMessage = "O estado não pode ultrapassar 64 caracteres.")]
        public string? Estado { get; set; }

        public object UsuarioCriadoExibir() //Método que retornará as informações do usuário criado
        {
            return new
            {
                PrimeiroNome,
                Sobrenome,
                Email,
                Email2,
                DataNascimento,
                Genero,
                Pais,
                Cidade,
                Estado
            };
        }
    }
}
