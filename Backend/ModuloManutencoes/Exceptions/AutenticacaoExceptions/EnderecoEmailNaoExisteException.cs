namespace ModuloManutencoes.Exceptions.AutenticacaoExceptions
{
    public class EnderecoEmailNaoExisteException : Exception
    {
        public EnderecoEmailNaoExisteException()
            : base("O endereço de e-mail informado não foi localizado.")
        {

        }
    }
}
