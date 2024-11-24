using BaseballSim.Core.Models;
namespace BaseballSim.Core.Interfaces;

public interface IGameRepository
{
    void Create(Game game);
    IEnumerable<Game> ReadAll();
    IEnumerable<Game> ReadAllByTeamId(int id);
    Game ReadById(int id);
    void Update(Game game);
    void Delete(int id);
}
