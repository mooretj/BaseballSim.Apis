using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;

namespace BaseballSim.DAL.Repos;

public class GamesRepo(BaseballSimDbContext context) : IGameRepository
{
    public void Create(Game game)
    {
        context.Games.Add(game);
        context.SaveChanges();
    }

    public IEnumerable<Game> ReadAll()
    {
        return context.Games.ToList();
    }

    public IEnumerable<Game> ReadAllByTeamId(int id)
    {
        return context.Games.Where(g => g.AwayTeamId == id || g.HomeTeamId == id).ToList();
    }

    public Game ReadById(int id)
    {
        return context.Games.Find(id);
    }

    public void Update(Game game)
    {
        var gameToUpdate = context.Games.Find(game.Id);
        if(gameToUpdate != null)
        {
            context.Entry(gameToUpdate).CurrentValues.SetValues(game);
            context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var gameToDelete = context.Games.Find(id);
        if (gameToDelete != null)
        {
            context.Games.Remove(gameToDelete);
        }
    }
}
