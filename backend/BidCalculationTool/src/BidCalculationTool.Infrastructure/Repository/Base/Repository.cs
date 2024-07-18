
using System.Collections.Generic;

namespace BidCalculationTool.Infrastructure.Repository.Base {
    [ExcludeFromCodeCoverage]
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
        protected readonly ILogger _logger;

        protected Repository(ILogger<Repository<TEntity>> logger) {
            _logger = logger;
        }

        public Task<TEntity> AddAsync(TEntity entity) {
            return Task.FromResult(entity);
        }

        public Task<int> CommitAsync() {
            return Task.FromResult(0);
        }

        public Task DeleteAsync(TEntity entity) {
            return Task.CompletedTask;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync() {
            var list = new List<TEntity>();
            return Task.FromResult((IEnumerable<TEntity>)list);
        }

        public Task<TEntity> GetByIdAsync(int id) {
            return null!;
        }

        public Task UpdateAsync(TEntity entity) {
            return Task.CompletedTask;
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) { }

        }
    }
}
