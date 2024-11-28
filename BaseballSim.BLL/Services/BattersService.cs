using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using BaseballSim.Protos;

namespace BaseballSim.BLL.Services;

public class BattersService(IBatterRepository repo) : IBattersService
{
    public Task<List<Batter>> GetAllBattersAsync(CancellationToken cancellationToken = default)
    {
        var batters = repo.ReadAllBattersAsync(cancellationToken);
        return batters;
    }

    public Task<List<Batter>> GetBattersByTeamIdAsync(int teamId, CancellationToken cancellationToken = default)
    {
        var batters = repo.ReadAllBattersByTeamIdAsync(teamId, cancellationToken);
        return batters;
    }

    public Task<List<Batter>> GetBattersByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var batters = repo.ReadBattersByNameAsync(name, cancellationToken);
        return batters;
    }

    public Task<Batter> GetBatterByIdAsync(int batterId, CancellationToken cancellationToken = default)
    {
        var batter = repo.ReadBatterByIdAsync(batterId, cancellationToken);
        return batter;
    }

    public Task<EmptyBatterResponse> CreateBatterAsync(Batter batter, CancellationToken cancellationToken = default)
    {
        repo.CreateBatterAsync(batter, cancellationToken);
        return Task.FromResult(new EmptyBatterResponse());
    }

    public Task<EmptyBatterResponse> UpdateBatterAsync(Batter batter, CancellationToken cancellationToken = default)
    {
        repo.UpdateBatterAsync(batter, cancellationToken);
        return Task.FromResult(new EmptyBatterResponse());
    }

    public Task<EmptyBatterResponse> DeleteBatterAsync(int batterId, CancellationToken cancellationToken = default)
    {
        repo.DeleteBatterByIdAsync(batterId, cancellationToken);
        return Task.FromResult(new EmptyBatterResponse());
    }
}
