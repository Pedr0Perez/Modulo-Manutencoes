namespace ModuloManutencoes.Exceptions.TipoDispositivoExceptions
{
    public class TipoDispositivoNaoEncontradoException : Exception
    {
        public TipoDispositivoNaoEncontradoException() :
            base($"O tipo de dispositivo do ID fornecido não existe.")
        {

        }
    }
}
