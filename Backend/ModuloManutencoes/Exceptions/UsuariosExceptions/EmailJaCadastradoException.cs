namespace ModuloManutencoes.Exceptions.UsuariosExceptions
{
    public class EmailJaCadastradoException : Exception
    {
        public EmailJaCadastradoException()
            : base($"O e-mail fornecido já está cadastrado.")
        {
        }
    }
}
