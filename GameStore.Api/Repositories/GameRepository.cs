using GameStore.Api.Database;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Repositories;

public class GameRepository(ApplicationDbContext context) : IGameRepository
{
    public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Games.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Game?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await context.Games.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
    }

    public async Task AddAsync(Game game,CancellationToken cancellationToken = default)
    {
        await context.Games.AddAsync(game,cancellationToken);
         await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Game game,CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Game game,CancellationToken cancellationToken = default)
    {
        context.Games.Remove(game);
        await context.SaveChangesAsync(cancellationToken);
    }
}