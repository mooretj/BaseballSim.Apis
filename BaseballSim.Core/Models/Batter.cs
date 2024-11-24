namespace BaseballSim.Core.Models;

public class Batter
{
    public int PlayerId { get; set; }
    public int TeamId { get; set; }
    public string Name { get; set; }
    public int PlateAppearances { get; set; }
    public Position Position { get; set; }
    public int AtBats { get; set; }
    public int Runs { get; set; }
    public int Hits { get; set; }
    public int Singles { get; set; }
    public int Doubles { get; set; }
    public int Triples { get; set; }
    public int HomeRuns { get; set; }
    public int Rbis { get; set; }
    public int Walks { get; set; }
    public int StrikeOuts { get; set; }
    public float BattingAvg { get; set; }
    public int TotalPitchesSeen { get; set; }
    public int TotalStrikes { get; set; }
    public int TotalBalls { get; set; }
    public virtual Team Team { get; set; }
}
