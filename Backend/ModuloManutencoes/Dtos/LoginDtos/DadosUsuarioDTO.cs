namespace ModuloManutencoes.Dtos.LoginDtos
{
    public class DadosUsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Genero { get; set; } = null!;
    }
}
