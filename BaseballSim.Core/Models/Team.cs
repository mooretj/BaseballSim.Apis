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
    public string Name { get; set; }
    /// <summary>
    /// League in which the Team plays
    /// </summary>
    public string League { get; set; }
    /// <summary>
    /// Division in which the Team plays
    /// </summary>
    public string Division { get; set; }
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
