using BaseballSim.Protos;

namespace BaseballSim.Core.Models;

/// <summary>
/// Pitcher definition
/// </summary>
public class Pitcher
{
    /// <summary>
    /// The unique identifier of a Pitcher
    /// </summary>
    public int PlayerId { get; set; }
    /// <summary>
    /// The ID of the Team the Pitcher is assigned
    /// </summary>
    public int TeamId { get; set; }
    /// <summary>
    /// The Name of the Pitcher
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// How many Batters this Pitcher has faced
    /// </summary>
    public int BattersFaced { get; set; }
    /// <summary>
    /// How man Pitches this Pitcher has thrown
    /// </summary>
    public int TotalPitches { get; set; }
    /// <summary>
    /// How many Runs this Pitcher has allowed
    /// </summary>
    public int Runs { get; set; }
    /// <summary>
    /// How many Hits this Pitcher has allowed
    /// </summary>
    public int Hits { get; set; }
    /// <summary>
    /// How many Singles this Pitcher has allowed
    /// </summary>
    public int Singles { get; set; }
    /// <summary>
    /// How many Doubles this Pitcher has allowed
    /// </summary>
    public int Doubles { get; set; }
    /// <summary>
    /// How many Triples this Pitcher has allowed
    /// </summary>
    public int Triples { get; set; }
    /// <summary>
    /// How many Home Runs this Pitcher has allowed
    /// </summary>
    public int HomeRuns { get; set; }
    /// <summary>
    /// How many Walks this Pitcher has allowed
    /// </summary>
    public int Walks { get; set; }
    /// <summary>
    /// How many Strike Outs this Pitcher has accumulated
    /// </summary>
    public int StrikeOuts { get; set; }
    /// <summary>
    /// How many Strikes this Pitcher has thrown
    /// </summary>
    public int Strikes { get; set; }
    /// <summary>
    /// How many Balls this Pitcher has thrown
    /// </summary>
    public int Balls { get; set; }
    /// <summary>
    /// The Batting Average Against this Pitcher
    /// </summary>
    public float AvgAgainst { get; set; }
    /// <summary>
    /// Virtual Team this Pitcher is assigned to
    /// </summary>
    public virtual Team Team { get; set; } = null!;
    
    /// <summary>
    /// The Earned Run Average of this Pitcher
    /// </summary>
    public float ERA { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    public Pitcher() {}
    
    /// <summary>
    /// Constructor method to convert a PitcherDetail into a Pitcher object
    /// </summary>
    /// <param name="detail"></param>
    public Pitcher(PitcherDetail detail)
    {
        PlayerId = detail.PlayerId;
        TeamId = detail.TeamId;
        Name = detail.Name;
        BattersFaced = detail.BattersFaced;
        TotalPitches = detail.TotalPitches;
        Runs = detail.Runs;
        Hits = detail.Hits;
        Singles = detail.Singles;
        Doubles = detail.Doubles;
        Triples = detail.Triples;
        HomeRuns = detail.HomeRuns;
        Walks = detail.Walks;
        StrikeOuts = detail.StrikeOuts;
        Strikes = detail.Strikes;
        Balls = detail.Balls;
        AvgAgainst = detail.AvgAgainst;
        ERA = detail.Era;
    }

    /// <summary>
    /// Method to convert a Pitcher object to a PitcherDetail
    /// </summary>
    /// <returns></returns>
    public PitcherDetail ToDetail()
    {
        return new PitcherDetail
        {
            PlayerId = PlayerId,
            TeamId = TeamId,
            Name = Name,
            BattersFaced = BattersFaced,
            TotalPitches = TotalPitches,
            Runs = Runs,
            Hits = Hits,
            Singles = Singles,
            Doubles = Doubles,
            Triples = Triples,
            HomeRuns = HomeRuns,
            Walks = Walks,
            StrikeOuts = StrikeOuts,
            Strikes = Strikes,
            Balls = Balls,
            AvgAgainst = AvgAgainst,
            Era = ERA,
        };
    }
}
