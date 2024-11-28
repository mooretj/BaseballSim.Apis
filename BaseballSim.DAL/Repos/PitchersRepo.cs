using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseballSim.DAL.Repos;

public class PitchersRepo(BaseballSimDbContext context) : IPitcherRepository
{
    public void CreatePitcherAsync(Pitcher pitcher, CancellationToken cancellationToken = default)
    {
        var newPitcher = context.Pitchers.Find(pitcher.PlayerId);
        if (newPitcher == null)
        {
            context.Pitchers.Add(pitcher);
            context.SaveChangesAsync(cancellationToken);
        }
        throw new DbUpdateException($"Player with id {pitcher.PlayerId} already exists.");
    }

    public Task<List<Pitcher>> ReadAllPitchersAsync(CancellationToken cancellationToken = default)
    {
        return context.Pitchers.ToListAsync(cancellationToken);
    }

    public Task<Pitcher> ReadPitcherByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var pitcher = context.Pitchers.Find(id);
        if (pitcher == null)
        {
            throw new InvalidOperationException($"Player with id {id} does not exist.");
        }
        return Task.FromResult(pitcher);
    }

    public Task<List<Pitcher>> ReadPitcherByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var pitchers = context.Pitchers.Where(p => p.Name.Contains(name)).ToListAsync(cancellationToken);
        return pitchers;
    }

    public Task<List<Pitcher>> ReadAllPitchersByTeamIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var pitchers = context.Pitchers.Where(p => p.TeamId == id).ToListAsync(cancellationToken);
        return pitchers;
    }

    public void UpdatePitcherAsync(Pitcher pitcher, CancellationToken cancellationToken = default)
    {
        var pitcherToUpdate = context.Pitchers.Find(pitcher.PlayerId);
        if (pitcherToUpdate != null)
        {
            context.Entry(pitcherToUpdate).CurrentValues.SetValues(pitcher);
            context.SaveChangesAsync(cancellationToken);
        }
        throw new InvalidOperationException($"Player {pitcher.PlayerId} does not exist.");
    }

    public void DeletePitcherByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var pitcherToDelete = context.Pitchers.Find(id);
        if (pitcherToDelete != null)
        {
            context.Pitchers.Remove(pitcherToDelete);
            context.SaveChangesAsync(cancellationToken);
        }
        throw new InvalidOperationException($"Player with id {id} does not exist.");
    }
}
