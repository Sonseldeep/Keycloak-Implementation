using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public interface IGameRepository
{
    Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Game?> GetByIdAsync(string id,CancellationToken cancellationToken = default);
    Task AddAsync(Game game, CancellationToken cancellationToken = default);
    Task UpdateAsync(Game game,CancellationToken cancellationToken = default);
    Task DeleteAsync(Game game,CancellationToken cancellationToken = default);
}