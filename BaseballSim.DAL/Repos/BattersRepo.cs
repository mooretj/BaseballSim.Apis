using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseballSim.DAL.Repos;

public class BattersRepo(BaseballSimDbContext context) : IBatterRepository
{
    public void CreateBatterAsync(Batter batter, CancellationToken cancellationToken = default)
    {
        var newBatter = context.Batters.Find(batter.PlayerId);
        if (newBatter == null)
        {
            context.Batters.Add(batter);
            context.SaveChangesAsync(cancellationToken);
        }
        throw new DbUpdateException($"Batter with id {batter.PlayerId} already exists.");
    }

    public Task<List<Batter>> ReadAllBattersAsync(CancellationToken cancellationToken = default)
    {
        return context.Batters.ToListAsync(cancellationToken);
    }

    public Task<List<Batter>> ReadAllBattersByTeamIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var batters = context.Batters.Where(b => b.TeamId == id).ToListAsync(cancellationToken);
        return batters;
    }

    public Task<Batter> ReadBatterByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var batter = context.Batters.Find(id);
        if (batter == null)
        {
            throw new InvalidOperationException($"Batter with id {id} does not exist.");
        }
        return Task.FromResult(batter);
    }

    public Task<List<Batter>> ReadBattersByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var batters = context.Batters.Where(b => b.Name.Contains(name)).ToListAsync(cancellationToken);
        return batters;
    }

    public void UpdateBatterAsync(Batter batter, CancellationToken cancellationToken = default)
    {
        var batterToUpdate = context.Batters.Find(batter.PlayerId);
        if (batterToUpdate != null)
        {
            context.Entry(batterToUpdate).CurrentValues.SetValues(batter);
            context.SaveChangesAsync(cancellationToken);
        }
        throw new InvalidOperationException($"Batter {batter.PlayerId} does not exist.");
    }

    public void DeleteBatterByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var batterToDelete = context.Batters.Find(id);
        if (batterToDelete != null)
        {
            context.Batters.Remove(batterToDelete);
            context.SaveChangesAsync(cancellationToken);
        }
        throw new InvalidOperationException($"Batter {id} does not exist.");
    }
}
