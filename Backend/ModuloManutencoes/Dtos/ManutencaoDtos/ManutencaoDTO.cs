using System.ComponentModel.DataAnnotations;

namespace ModuloManutencoes.Dtos.ManutencaoDtos
{
    public class ManutencaoDTO
    {
        [Required(ErrorMessage = "O dispositivo da manutenção é obrigatório.")]
        public int IdDispositivo { get; set; }
        [Required(ErrorMessage = "O usuário da manutenção é obrigatório.")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "A data de criação da manutenção é obrigatória.")]
        public DateTime DataCriacao { get; set; }
        [Required(ErrorMessage = "A descrição da manutenção é obrigatória.")]
        [MinLength(1, ErrorMessage = "A descrição da manutenção não pode estar vazia.")]
        public string Description { get; set; } = null!;
    }
}
