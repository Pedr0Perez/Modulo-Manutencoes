namespace ModuloManutencoes.Exceptions.DispositivoExceptions
{
    public class DispositivoJaExisteException : Exception
    {
        public DispositivoJaExisteException()
        : base($"Já existe um dispositivo com o nome fornecido.")
        {

        }
    }
}
