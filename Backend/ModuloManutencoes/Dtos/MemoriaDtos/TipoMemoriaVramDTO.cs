using System.ComponentModel.DataAnnotations;

namespace ModuloManutencoes.Dtos.MemoriaDtos
{
    public class TipoMemoriaVramDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "A descrição do tipo de memória VRAM é obrigatória.")]
        [MaxLength(50, ErrorMessage = "A descrição não pode ultrapassar 50 caracteres.")]
        public string Descricao { get; set; } = null!;
    }
}
