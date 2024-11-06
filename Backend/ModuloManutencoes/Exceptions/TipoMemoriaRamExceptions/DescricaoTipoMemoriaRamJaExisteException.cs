namespace ModuloManutencoes.Exceptions.TipoMemoriaRamExceptions
{
    public class DescricaoTipoMemoriaRamJaExisteException : Exception
    {
        public DescricaoTipoMemoriaRamJaExisteException()
            : base($"Já existe um tipo de memória RAM com a descrição fornecida.")
        { }
    }
}
