namespace ModuloManutencoes.Exceptions.AutenticacaoExceptions
{
    public class SenhaIncorretaException : Exception
    {
        public SenhaIncorretaException()
            : base("A senha informada é inválida.")
        {

        }
    }
}
