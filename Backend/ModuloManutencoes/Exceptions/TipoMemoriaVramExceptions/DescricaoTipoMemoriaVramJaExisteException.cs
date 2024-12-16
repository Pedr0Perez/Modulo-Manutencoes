namespace ModuloManutencoes.Exceptions.TipoMemoriaVramExceptions
{
    public class DescricaoTipoMemoriaVramJaExisteException : Exception
    {
        public DescricaoTipoMemoriaVramJaExisteException()
            : base($"Já existe um tipo de memória VRAM com a descrição fornecida.")
        { }
    }
}
