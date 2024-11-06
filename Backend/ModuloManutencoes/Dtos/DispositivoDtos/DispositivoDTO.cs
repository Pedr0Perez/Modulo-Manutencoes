using System.ComponentModel.DataAnnotations;

namespace ModuloManutencoes.Dtos.DispositivoDtos
{
    public class DispositivoDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "O tipo de dispositivo é obrigatório.")]
        public int Tipo { get; set; }
        [Required]
        [MaxLength(75, ErrorMessage = "O nome não pode ultrapassar 75 caracteres.")]
        public string Nome { get; set; } = null!;
        [MaxLength(50, ErrorMessage = "O CPU não pode ultrapassar 50 caracteres.")]
        public string? Cpu { get; set; }
        [MaxLength(50, ErrorMessage = "A GPU não pode ultrapassar 50 caracteres.")]
        public string? Gpu { get; set; }
        [MaxLength(50, ErrorMessage = "A placa mãe não pode ultrapassar 50 caracteres.")]
        public string? PlacaMae { get; set; }
        [MaxLength(50, ErrorMessage = "A fonte não pode ultrapassar 50 caracteres.")]
        public string? Fonte { get; set; }
        public int? Armazenamento { get; set; }
        public int? RamQuantidade { get; set; }
        public int? RamTipo { get; set; }
        public int? VramQuantidade { get; set; }
        public int? VramTipo { get; set; }
        [MaxLength(120, ErrorMessage = "A observação não pode ultrapassar 50 caracteres.")]
        public string? Observacao { get; set; }
    }
}
