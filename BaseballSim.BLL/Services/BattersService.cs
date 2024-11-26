using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;

namespace BaseballSim.BLL.Services;

public class BattersService(IBatterRepository repo)
{
    public Batter CreateBatter(Batter batter)
    {
        repo.Create(batter);
        return repo.ReadById(batter.PlayerId);
    }

    public IEnumerable<Batter> GetAllBatters()
    {
        return repo.ReadAll();
    }
    
    public Batter GetBattersByPlayerId(int playerId)
    {
        return repo.ReadById(playerId);
    }

    public void UpdateBatter(Batter batter)
    {
        repo.Update(batter);
    }

    public void DeleteBatter(int batterId)
    {
        repo.Delete(batterId);
    }
}
