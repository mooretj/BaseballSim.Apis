using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using Microsoft.EntityFrameworkCore;
namespace BaseballSim.DAL.Repos;

public class GamesRepo(BaseballSimDbContext context) : IGameRepository
{
    public Task<Game> CreateGameAsync(Game game, CancellationToken cancellationToken = default)
    {
        var newGame = context.Games.Find(game.Id);
        if (newGame == null)
        {
            context.Games.Add(game);
            context.SaveChangesAsync(cancellationToken);
            return Task.FromResult(game);
        }
        throw new DbUpdateException("Game already exists");
    }

    public Task<List<Game>> ReadAllAsync(CancellationToken cancellationToken = default)
    {
        return context.Games.ToListAsync(cancellationToken);
    }

    public Task<List<Game>> ReadAllByTeamIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return context.Games.Where(g => g.AwayTeamId == id || g.HomeTeamId == id).ToListAsync(cancellationToken);
    }

    public Task<Game> ReadGameByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var game = context.Games.Find(id);
        if (game == null)
        {
            throw new InvalidOperationException($"Game with id {id} not found");
        }
        return Task.FromResult(game);
    }

    public void UpdateGameAsync(Game game, CancellationToken cancellationToken = default)
    {
        var gameToUpdate = context.Games.Find(game.Id);
        if(gameToUpdate != null)
        {
            context.Entry(gameToUpdate).CurrentValues.SetValues(game);
            context.SaveChangesAsync(cancellationToken);
        }
        throw new InvalidOperationException($"Game with id {game.Id} not found");
    }

    public void DeleteGameAsync(int id, CancellationToken cancellationToken = default)
    {
        var gameToDelete = context.Games.Find(id);
        if (gameToDelete != null)
        {
            context.Games.Remove(gameToDelete);
            context.SaveChangesAsync(cancellationToken);
        }
        throw new InvalidOperationException($"Game with id {id} not found");
    }
}
