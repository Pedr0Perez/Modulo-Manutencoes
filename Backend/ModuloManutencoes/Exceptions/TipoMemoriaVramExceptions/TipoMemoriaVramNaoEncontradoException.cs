namespace ModuloManutencoes.Exceptions.TipoMemoriaVramExceptions
{
    public class TipoMemoriaVramNaoEncontradoException : Exception
    {
        public TipoMemoriaVramNaoEncontradoException()
            : base($"O tipo de memória VRAM do ID fornecido não existe.")
        {

        }
    }
}
