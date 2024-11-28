using BaseballSim.Protos;

namespace BaseballSim.Core.Models;

public class Pitcher
{
    public int PlayerId { get; set; }
    public int TeamId { get; set; }
    public string Name { get; set; }
    public int BattersFaced { get; set; }
    public int TotalPitches { get; set; }
    public int Runs { get; set; }
    public int Hits { get; set; }
    public int Singles { get; set; }
    public int Doubles { get; set; }
    public int Triples { get; set; }
    public int HomeRuns { get; set; }
    public int Walks { get; set; }
    public int StrikeOuts { get; set; }
    public int Strikes { get; set; }
    public int Balls { get; set; }
    public float AvgAgainst { get; set; }
    public virtual Team Team { get; set; }

    public Pitcher() {}

    public Pitcher(PitcherDetail detail)
    {
        
    }
}
