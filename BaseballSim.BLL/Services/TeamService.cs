using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;

namespace BaseballSim.BLL.Services;

public class TeamService(ITeamRepository repo)
{
    public Team Create(Team team)
    {
        repo.Create(team);
        return repo.ReadById(team.Id);
    }

    public IEnumerable<Team> GetAllTeams()
    {
        return repo.ReadAll();
    }

    public Team GetTeamById(int teamId)
    {
        return repo.ReadById(teamId);
    }

    public void Update(Team team)
    {
        repo.Update(team);
    }

    public void Delete(Team team)
    {
        repo.Delete(team.Id);
    }
}
