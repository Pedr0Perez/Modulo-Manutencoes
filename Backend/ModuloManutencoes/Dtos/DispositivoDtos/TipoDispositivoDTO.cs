using System.ComponentModel.DataAnnotations;

namespace ModuloManutencoes.Dtos.DispositivoDtos
{
    public class TipoDispositivoDTO
    {
        [Required(ErrorMessage = "A descrição do tipo de dispositivo é obrigatória.")]
        [MaxLength(50, ErrorMessage = "A descrição não pode ultrapassar 50 caracteres.")]
        public string Descricao { get; set; } = null!;
    }
}
