using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;

namespace BaseballSim.DAL.Repos;

public class BattersRepo(BaseballSimDbContext context) : IBatterRepository
{
    public void Create(Batter batter)
    {
        context.Batters.Add(batter);
        context.SaveChanges();
    }

    public IEnumerable<Batter> ReadAll()
    {
        return context.Batters.ToList();
    }

    public IEnumerable<Batter> ReadAllByTeamId(int id)
    {
        return context.Batters.Where(b => b.TeamId == id).ToList();
    }

    public Batter ReadById(int id)
    {
        return context.Batters.Find(id);
    }

    public Batter ReadByName(string name)
    {
        return context.Batters.FirstOrDefault(b => b.Name == name);
    }

    public void Update(Batter batter)
    {
        var batterToUpdate = context.Batters.Find(batter.PlayerId);
        if (batterToUpdate != null)
        {
            context.Entry(batterToUpdate).CurrentValues.SetValues(batter);
            context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var batterToDelete = context.Batters.Find(id);
        if (batterToDelete != null)
        {
            context.Batters.Remove(batterToDelete);
        }
    }
}
