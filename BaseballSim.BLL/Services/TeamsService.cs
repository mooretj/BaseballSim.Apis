using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;

namespace BaseballSim.BLL.Services;

public class TeamsService(ITeamRepository repo) : ITeamRepository
{
    public Task<Team> CreateTeamAsync(Team team, CancellationToken cancellationToken = default)
    {
        repo.CreateTeamAsync(team, cancellationToken);
        return Task.FromResult(team);
    }

    public IEnumerable<Team> ReadAllAsync(CancellationToken cancellationToken = default)
    {
        return repo.ReadAllAsync();
    }

    public Team ReadByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return repo.ReadByIdAsync(id);
    }

    public void UpdateTeamAsync(Team team, CancellationToken cancellationToken = default)
    {
        repo.UpdateTeamAsync(team, cancellationToken);
    }

    public void DeleteTeamAsync(int id, CancellationToken cancellationToken = default)
    {
        repo.DeleteTeamAsync(id, cancellationToken);
    }
}
