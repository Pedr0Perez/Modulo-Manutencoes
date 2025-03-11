using ModuloManutencoes.Dtos.DispositivoDtos;

namespace ModuloManutencoes.Services.Interfaces
{
    public interface IValidadorDispositivoService
    {
        Task ValidarDispositivo(DispositivoDTO dispositivo);
        Task ValidarDispositivo(DispositivoDTO dispositivo, int id);
        Task ValidarDispositivo(int id);
    }
}
