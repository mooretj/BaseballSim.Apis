using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;

namespace BaseballSim.BLL.Services;

public class GamesService(IGameRepository repo)
{
    public Game CreateGame(Game game)
    {
        repo.Create(game);
        return repo.ReadById(game.Id);
    }

    public IEnumerable<Game> GetAllGames()
    {
        return repo.ReadAll();
    }

    public Game GetGameById(int gameId)
    {
        return repo.ReadById(gameId);
    }

    public void UpdateGame(Game game)
    {
        repo.Update(game);
    }

    public void DeleteGame(Game game)
    {
        repo.Delete(game.Id);
    }
}
