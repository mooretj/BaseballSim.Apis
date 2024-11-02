using System.Collections;
using BaseballSim.Core.Models;

namespace BaseballSim.Core.Interfaces;

public interface IBatterRepository
{
    void Create(Batter batter);
    IEnumerable<Batter> ReadAll();
    IEnumerable<Batter> ReadAllByTeamId(int id);
    Batter ReadById(int id);
    Batter ReadByName(string name);
    void Update(Batter batter);
    void Delete(int id);
}