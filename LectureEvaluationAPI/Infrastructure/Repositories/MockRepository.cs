using LectureEvaluationAPI.Application.Repositories;
using LectureEvaluationAPI.Domain.Entities;

namespace LectureEvaluationAPI.Infrastructure.Repositories;

public class MockRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity {
    // entities are stored in an ID -> entity dictionary simulating a db index
    protected readonly Dictionary<int, TEntity> Store = new();
    
    // id counter to simulate value generation for id column
    private int _currentId = 1;

    public Task<List<TEntity>> FindAllAsync() => Task.FromResult(Store.Values.ToList());

    public Task<TEntity?> FindByIdAsync(int id) => Task.FromResult(Store.TryGetValue(id, out var entity) ? entity : null);

    public Task<TEntity> AddAsync(TEntity entity) {
        
        if (entity.Id == 0) {  // Auto-generate ID if not set
            entity.Id = _currentId++;
        }
        Store[entity.Id] = entity;
        return Task.FromResult(entity);
    }

    public Task<TEntity> UpdateAsync(TEntity entity) {
        if (!Store.ContainsKey(entity.Id)) {
            throw new KeyNotFoundException($"Entity with ID {entity.Id} not found.");
        }
        Store[entity.Id] = entity;
        return Task.FromResult(entity);
    }

    public Task<TEntity> DeleteAsync(TEntity entity)
    {
        if (!Store.ContainsKey(entity.Id))
        {
            throw new KeyNotFoundException($"Entity with ID {entity.Id} not found.");
        }
        
        Store.Remove(entity.Id);
        return Task.FromResult(entity);
    }
}