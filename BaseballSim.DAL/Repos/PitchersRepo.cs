using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;

namespace BaseballSim.DAL.Repos;

public class PitchersRepo(BaseballSimDbContext context) : IPitcherRepository
{
    public void Create(Pitcher pitcher)
    {
        context.Pitchers.Add(pitcher);
        context.SaveChanges();
    }

    public IEnumerable<Pitcher> ReadAll()
    {
        return context.Pitchers.ToList();
    }

    public Pitcher ReadById(int id)
    {
        return context.Pitchers.Find(id);
    }

    public Pitcher ReadByName(string name)
    {
        return context.Pitchers.FirstOrDefault(p => p.Name == name);
    }

    public IEnumerable<Pitcher> ReadAllByTeamId(int id)
    {
        return context.Pitchers.Where(p => p.TeamId == id).ToList();
    }

    public void Update(Pitcher pitcher)
    {
        var pitcherToUpdate = context.Pitchers.Find(pitcher.PlayerId);
        if (pitcherToUpdate != null)
        {
            context.Entry(pitcherToUpdate).CurrentValues.SetValues(pitcher);
            context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var pitcherToRemove = context.Pitchers.Find(id);
        if (pitcherToRemove != null)
        {
            context.Pitchers.Remove(pitcherToRemove);
        }
    }
}
