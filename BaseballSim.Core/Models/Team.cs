using System.Collections;

namespace BaseballSim.Core.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string League { get; set; }
    public string Division { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public virtual ICollection<Pitcher> Pitchers { get; set; }
    public virtual ICollection<Batter> Batters { get; set; }
}