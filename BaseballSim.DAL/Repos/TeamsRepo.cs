using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;

namespace BaseballSim.DAL.Repos;

public class TeamsRepo(BaseballSimDbContext context) : ITeamRepository
{
    public void Create(Team team)
    {
        context.Teams.Add(team);
        context.SaveChanges();
    }
    
    public IEnumerable<Team> ReadAll()
    {
        return context.Teams.ToList();
    }

    public Team ReadById(int id)
    {
        return context.Teams.Find(id);
    }

    public void Update(Team team)
    {
        var teamToUpdate = context.Teams.Find(team.Id);
        if(teamToUpdate != null)
        {
            context.Entry(teamToUpdate).CurrentValues.SetValues(team);
            context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var teamToDelete = context.Teams.Find(id);
        if (teamToDelete != null)
        {
            context.Teams.Remove(teamToDelete);
        }
    }
}
