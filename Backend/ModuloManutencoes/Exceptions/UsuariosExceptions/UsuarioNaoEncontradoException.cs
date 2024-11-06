namespace ModuloManutencoes.Exceptions.UsuariosExceptions
{
    public class UsuarioNaoEncontradoException : Exception
    {
        public UsuarioNaoEncontradoException()
            : base($"O usuário do ID fornecido não existe.")
        {
        }
    }
}
