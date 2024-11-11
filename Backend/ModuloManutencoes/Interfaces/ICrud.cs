using ModuloManutencoes.Dtos.MensagemDtos;

namespace ModuloManutencoes.Interfaces
{
    public interface ICrud<TKey, TEntity, TEntityGet> where TEntity : class
    {
        Task<IEnumerable<TEntityGet>> GetAll();
        Task<TEntityGet?> GetById(TKey key);
        Task<MensagemAoClienteDTO> Create(TEntity entity);
        Task<MensagemAoClienteDTO> Update(TKey id, TEntity entity);
        Task<MensagemAoClienteDTO> Delete(TKey id);

    }
}
