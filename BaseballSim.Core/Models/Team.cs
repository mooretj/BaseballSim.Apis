using System.Collections;
using BaseballSim.Protos;

namespace BaseballSim.Core.Models;
/// <summary>
/// Team definition
/// </summary>
public class Team
{
    /// <summary>
    /// The unique ID for the Team
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Name of the Team
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// League in which the Team plays
    /// </summary>
    public string League { get; set; } = null!;

    /// <summary>
    /// Division in which the Team plays
    /// </summary>
    public string Division { get; set; } = null!;

    /// <summary>
    /// Total Wins Team has
    /// </summary>
    public int Wins { get; set; }
    /// <summary>
    /// Total Losses Team has
    /// </summary>
    public int Losses { get; set; }

    /// <summary>
    /// List of Pitchers assigned to Team
    /// </summary>
    public virtual ICollection<Pitcher> Pitchers { get; set; } = new List<Pitcher>();
    
    /// <summary>
    /// List of Batters assigned to Team
    /// </summary>
    public virtual ICollection<Batter> Batters { get; set; } = new List<Batter>();

    /// <summary>
    /// Default constructor
    /// </summary>
    public Team() {}

    /// <summary>
    /// Method to convert a TeamDetail to a Team object
    /// </summary>
    /// <param name="detail"></param>
    public Team(TeamDetail detail)
    {
        Id = detail.TeamId;
        Name = detail.TeamName;
        League = detail.League;
        Division = detail.Division;
        Wins = detail.Wins;
        Losses = detail.Losses;
    }
    
    /// <summary>
    /// Converts Team object to a gRPC compatible TeamDetail object
    /// </summary>
    /// <returns>The converted TeamDetail object</returns>
    public TeamDetail ToDetail()
    {
        return new TeamDetail
        {
            TeamId = Id,
            TeamName = Name,
            League = League,
            Division = Division,
            Wins = Wins,
            Losses = Losses
        };
    }
}
