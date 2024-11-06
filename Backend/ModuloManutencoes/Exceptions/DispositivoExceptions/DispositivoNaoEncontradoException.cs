namespace ModuloManutencoes.Exceptions.DispositivoExceptions
{
    public class DispositivoNaoEncontradoException : Exception
    {
        public DispositivoNaoEncontradoException() :
            base($"O dispositivo do ID fornecido não existe.")
        { }
    }
}
