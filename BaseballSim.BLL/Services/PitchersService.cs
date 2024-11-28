using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using BaseballSim.Protos;

namespace BaseballSim.BLL.Services;

public class PitchersService(IPitcherRepository repo) : IPitchersService
{
    public Task<List<Pitcher>> GetAllPitchersAsync(CancellationToken cancellationToken = default)
    {
        var pitchers = repo.ReadAllPitchersAsync(cancellationToken);
        return pitchers;
    }

    public Task<List<Pitcher>> GetAllPitchersByTeamIdAsync(int teamId, CancellationToken cancellationToken = default)
    {
        var pitchers = repo.ReadAllPitchersByTeamIdAsync(teamId, cancellationToken);
        return pitchers;
    }

    public Task<List<Pitcher>> GetAllPitchersByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var pitchers = repo.ReadPitcherByNameAsync(name, cancellationToken);
        return pitchers;
    }

    public Task<Pitcher> GetPitcherByIdAsync(int pitcherId, CancellationToken cancellationToken = default)
    {
        var pitcher = repo.ReadPitcherByIdAsync(pitcherId, cancellationToken);
        return pitcher;
    }

    public Task<EmptyPitcherResponse> CreatePitcherAsync(Pitcher pitcher, CancellationToken cancellationToken = default)
    {
        repo.CreatePitcherAsync(pitcher, cancellationToken);
        return Task.FromResult(new EmptyPitcherResponse());
    }

    public Task<EmptyPitcherResponse> UpdatePitcherAsync(Pitcher pitcher, CancellationToken cancellationToken = default)
    {
        repo.UpdatePitcherAsync(pitcher, cancellationToken);
        return Task.FromResult(new EmptyPitcherResponse());
    }

    public Task<EmptyPitcherResponse> DeletePitcherAsync(int pitcherId, CancellationToken cancellationToken = default)
    {
        repo.DeletePitcherByIdAsync(pitcherId, cancellationToken);
        return Task.FromResult(new EmptyPitcherResponse());
    }
}
