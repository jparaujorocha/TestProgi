
namespace BidCalculationTool.Domain.Repository.Base {
    public interface IRepository<TEntity> : IDisposable where TEntity : class {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> CommitAsync();
    }
}
