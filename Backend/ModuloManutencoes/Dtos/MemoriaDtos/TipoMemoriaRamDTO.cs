using System.ComponentModel.DataAnnotations;

namespace ModuloManutencoes.Dtos.MemoriaDtos
{
    public class TipoMemoriaRamDTO
    {
        [Required(ErrorMessage = "A descrição do tipo de memória RAM é obrigatória.")]
        [MaxLength(50, ErrorMessage = "A descrição não pode ultrapassar 50 caracteres.")]
        public string Descricao { get; set; } = null!;
    }
}
