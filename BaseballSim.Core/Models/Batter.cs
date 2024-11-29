using BaseballSim.Protos;

namespace BaseballSim.Core.Models;

/// <summary>
/// Batter definition
/// </summary>
public class Batter
{
    /// <summary>
    /// The unique identifier of a Batter
    /// </summary>
    public int PlayerId { get; set; }
    /// <summary>
    /// The ID of the Team the Batter is assigned
    /// </summary>
    public int TeamId { get; set; }
    /// <summary>
    /// The Name of the Batter
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// How many Plate Appearances this Batter has had 
    /// </summary>
    public int PlateAppearances { get; set; }
    /// <summary>
    /// The Position that this Batter plays in the field
    /// </summary>
    public Position Position { get; set; }
    /// <summary>
    /// How many At Bats this Batter has had ending in "Safe" or "Out"
    /// </summary>
    public int AtBats { get; set; }
    /// <summary>
    /// How many Runs this Batter has scored
    /// </summary>
    public int Runs { get; set; }
    /// <summary>
    /// How man Hits this Batter has
    /// </summary>
    public int Hits { get; set; }
    /// <summary>
    /// How man Singles this Batter has
    /// </summary>
    public int Singles { get; set; }
    /// <summary>
    /// How many Doubles this Batter has
    /// </summary>
    public int Doubles { get; set; }
    /// <summary>
    /// How many Triples this Batter has
    /// </summary>
    public int Triples { get; set; }
    /// <summary>
    /// How man Home Runs this Batter has
    /// </summary>
    public int HomeRuns { get; set; }
    /// <summary>
    /// How man Runs this Batter has driven in to score
    /// </summary>
    public int Rbis { get; set; }
    /// <summary>
    /// How man Walks this Batter has
    /// </summary>
    public int Walks { get; set; }
    /// <summary>
    /// How many Strikeouts this Batter has
    /// </summary>
    public int StrikeOuts { get; set; }
    /// <summary>
    /// The Batting Average this Batter has
    /// </summary>
    public float BattingAvg { get; set; }
    /// <summary>
    /// How many Pitches this Batter has seen
    /// </summary>
    public int TotalPitchesSeen { get; set; }
    /// <summary>
    /// How many Strikes this Batter has taken
    /// </summary>
    public int TotalStrikes { get; set; }
    /// <summary>
    /// How many Balls this Batter has taken
    /// </summary>
    public int TotalBalls { get; set; }
    /// <summary>
    /// Virtual Team this Batter is assigned to
    /// </summary>
    public virtual Team Team { get; set; } = null!;

    /// <summary>
    /// Default constructor
    /// </summary>
    public Batter() {}

    /// <summary>
    /// Constructor method to convert a BatterDetail to a Batter object
    /// </summary>
    /// <param name="detail"></param>
    public Batter(BatterDetail detail)
    {
        PlayerId = detail.PlayerId;
        TeamId = detail.TeamId;
        Name = detail.Name;
        PlateAppearances = detail.PlateAppearances;
        Position = Enum.Parse<Position>(detail.Position);
        AtBats = detail.AtBats;
        Runs = detail.Runs;
        Hits = detail.Hits;
        Singles = detail.Singles;
        Doubles = detail.Doubles;
        Triples = detail.Triples;
        HomeRuns = detail.HomeRuns;
        Rbis = detail.Rbis;
        Walks = detail.Walks;
        StrikeOuts = detail.Strikeouts;
        BattingAvg = detail.BattingAvg;
        TotalPitchesSeen = detail.TotalPitchesSeen;
        TotalStrikes = detail.TotalStrikes;
        TotalBalls = detail.TotalBalls;
    }
    
    /// <summary>
    /// Method to convert a Batter object to a BatterDetail
    /// </summary>
    /// <returns></returns>
    public BatterDetail ToDetail()
    {
        return new BatterDetail
        {
            PlayerId = PlayerId,
            TeamId = TeamId,
            Name = Name,
            PlateAppearances = PlateAppearances,
            Position = Position.ToString(),
            AtBats = AtBats,
            Runs = Runs,
            Hits = Hits,
            Singles = Singles,
            Doubles = Doubles,
            Triples = Triples,
            HomeRuns = HomeRuns,
            Rbis = Rbis,
            Walks = Walks,
            Strikeouts = StrikeOuts,
            BattingAvg = BattingAvg,
            TotalPitchesSeen = TotalPitchesSeen,
            TotalStrikes = TotalStrikes,
            TotalBalls = TotalBalls,
        };
    }
    
}
