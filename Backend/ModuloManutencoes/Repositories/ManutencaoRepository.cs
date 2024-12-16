using System.ComponentModel.DataAnnotations;

namespace ModuloManutencoes.Repositories
{
    public class ManutencaoRepository
    {
        [Required]
        public int IdDispositivo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Description { get; set; } = null!;
    }
}
