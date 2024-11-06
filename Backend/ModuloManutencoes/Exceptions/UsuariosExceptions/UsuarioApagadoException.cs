namespace ModuloManutencoes.Exceptions.UsuariosExceptions
{
    public class UsuarioApagadoException : Exception
    {
        public UsuarioApagadoException()
            : base($"O usuário do ID fornecido não pode ser modificado, pois foi excluído.")
        {
        }
    }
}
