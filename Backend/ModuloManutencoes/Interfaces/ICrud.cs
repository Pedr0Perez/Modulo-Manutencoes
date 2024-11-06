using ModuloManutencoes.Dtos.MensagemDtos;

namespace ModuloManutencoes.Interfaces
{
    public interface ICrud<TKey, TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(TKey key);
        Task<MensagemAoClienteDTO> Create(TEntity entity);
        Task<MensagemAoClienteDTO> Update(TKey id, TEntity entity);
        Task<MensagemAoClienteDTO> Delete(TKey id);

    }
}
