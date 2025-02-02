using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseballSim.DAL.Repos;

public class TeamsRepo(BaseballSimDbContext context) : ITeamRepository
{
    public async Task<Team> CreateTeamAsync(Team team, CancellationToken cancellationToken = default)
    {
        var existingTeamId = await context.Teams.FindAsync(team.Id, cancellationToken);
        var existingTeamName = await context.Teams.FirstOrDefaultAsync(t => t.Name == team.Name, cancellationToken);
        if (existingTeamId != null)
        {
            throw new DbUpdateException($"Team with ID {team.Id} already exists");
        }
    
        if (existingTeamName != null)
        {
            throw new DbUpdateException($"Team with name '{team.Name}' already exists");
        }
        context.Teams.Add(team);
        await context.SaveChangesAsync(cancellationToken);
        return team;  
    }
    
    public Task<List<Team>> ReadAllAsync(CancellationToken cancellationToken = default)
    {
        var teams = context.Teams.ToListAsync(cancellationToken);
        return teams;
    }

    public Task<Team> ReadByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var team = context.Teams.Find(id);
        if (team == null)
        {
            throw new InvalidOperationException($"Team with id {id} not found");
        }
        return Task.FromResult(team);
    }

    public async Task UpdateTeamAsync(Team team, CancellationToken cancellationToken = default)
    {
        var teamToUpdate = context.Teams.Find(team.Id);
        if(teamToUpdate == null)
        {
            throw new InvalidOperationException($"Team with id {team.Id} not found");
        }
        context.Entry(teamToUpdate).CurrentValues.SetValues(team);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteTeamAsync(int id, CancellationToken cancellationToken = default)
    {
        var teamToDelete = context.Teams.Find(id);
        if (teamToDelete == null)
        {
            throw new InvalidOperationException($"Team with id {id} not found");
        }
        context.Teams.Remove(teamToDelete); 
        await context.SaveChangesAsync(cancellationToken);
    }
}
