using ModuloManutencoes.Dtos.MensagemDtos;

namespace ModuloManutencoes.Interfaces
{
    public interface ICrud<TKey, TEntity, TEntityGet> where TEntity : class
    {
        Task<IEnumerable<TEntityGet>> GetAll();
        Task<TEntityGet?> GetById(TKey key);
        Task Create(TEntity entity);
        Task Update(TKey id, TEntity entity);
        Task Delete(TKey id);

    }
}
