namespace ModuloManutencoes.Exceptions.TipoMemoriaRamExceptions
{
    public class TipoMemoriaRamNaoEncontradoException : Exception
    {
        public TipoMemoriaRamNaoEncontradoException()
            : base($"O tipo de memória RAM do ID fornecido não existe.")
        {

        }
    }
}
