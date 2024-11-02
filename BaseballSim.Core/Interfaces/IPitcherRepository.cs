using BaseballSim.Core.Models;

namespace BaseballSim.Core.Interfaces;

public interface IPitcherRepository
{
    void Create(Pitcher pitcher);
    IEnumerable<Pitcher> ReadAll();
    Pitcher ReadById(int id);
    Pitcher ReadByName(string name);
    IEnumerable<Pitcher> ReadAllByTeamId(int id);
    void Update(Pitcher pitcher);
    void Delete(int id);
}