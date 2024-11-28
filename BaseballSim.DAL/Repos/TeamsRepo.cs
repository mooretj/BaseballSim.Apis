using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseballSim.DAL.Repos;

public class TeamsRepo(BaseballSimDbContext context) : ITeamRepository
{
    public Task<Team> CreateTeamAsync(Team team, CancellationToken cancellationToken = default)
    {
        var newTeam = context.Teams.Find(team.Id);
        if (newTeam == null)
        {
          context.Teams.Add(team);
                  context.SaveChangesAsync(cancellationToken);
                  return Task.FromResult(team);  
        }
        throw new DbUpdateException("Team already exists");
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

    public void UpdateTeamAsync(Team team, CancellationToken cancellationToken = default)
    {
        var teamToUpdate = context.Teams.Find(team.Id);
        if(teamToUpdate != null)
        {
            context.Entry(teamToUpdate).CurrentValues.SetValues(team);
            context.SaveChangesAsync(cancellationToken);
        }
        throw new InvalidOperationException($"Team with id {team.Id} not found");
    }

    public void DeleteTeamAsync(int id, CancellationToken cancellationToken = default)
    {
        var teamToDelete = context.Teams.Find(id);
        if (teamToDelete != null)
        {
            context.Teams.Remove(teamToDelete);
            context.SaveChangesAsync(cancellationToken);
        }
        throw new InvalidOperationException($"Team with id {id} not found");
    }
}
