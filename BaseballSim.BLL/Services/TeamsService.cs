using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using BaseballSim.Protos;

namespace BaseballSim.BLL.Services;

public class TeamsService(ITeamRepository repo) : ITeamsService
{
    public Task<List<Team>> GetAllTeamsAsync(CancellationToken cancellationToken = default)
    {
        var teams = repo.ReadAllAsync(cancellationToken);
        return teams;
    }

    public Task<Team> GetTeamByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var team = repo.ReadByIdAsync(id, cancellationToken);
        return team;
    }

    public Task<EmptyTeamResponse> CreateTeamAsync(Team team, CancellationToken cancellationToken = default)
    {
        repo.CreateTeamAsync(team, cancellationToken);
        return Task.FromResult(new EmptyTeamResponse());
    }

    public Task<EmptyTeamResponse> UpdateTeamAsync(Team team, CancellationToken cancellationToken = default)
    {
        repo.UpdateTeamAsync(team, cancellationToken);
        return Task.FromResult(new EmptyTeamResponse());
    }

    public Task<EmptyTeamResponse> DeleteTeamAsync(int id, CancellationToken cancellationToken = default)
    {
        repo.DeleteTeamAsync(id, cancellationToken);
        return Task.FromResult(new EmptyTeamResponse());
    }
}
