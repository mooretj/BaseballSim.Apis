using BaseballSim.Core.Models;


namespace BaseballSim.Core.Interfaces;

public interface ITeamRepository
{
    void Create(Team team);
    IEnumerable<Team> ReadAll();
    Team ReadById(int id);
    void Update(Team team);
    void Delete(int id);
}