using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using BaseballSim.Protos;

namespace BaseballSim.BLL.Services;

public class GamesService(IGameRepository repo) : IGamesService
{
    public Task<List<Game>> GetAllGamesAsync(CancellationToken cancellationToken = default)
    {
        var games = repo.ReadAllAsync(cancellationToken);
        return games;
    }

    public Task<List<Game>> GetGamesByTeamIdAsync(int teamId, CancellationToken cancellationToken = default)
    {
        var games = repo.ReadAllByTeamIdAsync(teamId, cancellationToken);
        return games;
    }

    public Task<Game> GetGameByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var game = repo.ReadGameByIdAsync(id, cancellationToken);
        return game;
    }

    public Task<EmptyGameResponse> CreateGameAsync(Game game, CancellationToken cancellationToken = default)
    {
        repo.CreateGameAsync(game, cancellationToken);
        return Task.FromResult(new EmptyGameResponse());
    }

    public Task<EmptyGameResponse> UpdateGameAsync(Game game, CancellationToken cancellationToken = default)
    {
        repo.UpdateGameAsync(game, cancellationToken);
        return Task.FromResult(new EmptyGameResponse());
    }

    public Task<EmptyGameResponse> DeleteGameAsync(int id, CancellationToken cancellationToken = default)
    {
        repo.DeleteGameAsync(id, cancellationToken);
        return Task.FromResult(new EmptyGameResponse());
    }
}
