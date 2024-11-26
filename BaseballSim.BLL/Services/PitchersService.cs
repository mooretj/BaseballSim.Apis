using BaseballSim.Core.Interfaces;
using BaseballSim.Core.Models;

namespace BaseballSim.BLL.Services;

public class PitchersService(IPitcherRepository repo)
{
    public Pitcher CreatePitcher(Pitcher pitcher)
    {
        repo.Create(pitcher);
        return repo.ReadById(pitcher.PlayerId);
    }

    public IEnumerable<Pitcher> GetAllPitchers()
    {
        return repo.ReadAll();
    }

    public Pitcher GetPitcherById(int pitcherId)
    {
        return repo.ReadById(pitcherId);
    }

    public void UpdatePitcher(Pitcher pitcher)
    {
        repo.Update(pitcher);
    }

    public void DeletePitcherById(int pitcherId)
    {
        repo.Delete(pitcherId);
    }
}
