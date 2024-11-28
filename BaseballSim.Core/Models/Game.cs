using BaseballSim.Protos;
using Google.Protobuf.WellKnownTypes;

namespace BaseballSim.Core.Models;

/// <summary>
/// Game definition
/// </summary>
public class Game
{
    /// <summary>
    /// The unique identifier of a Game
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The Date the Game was played
    /// </summary>
    public DateTime GamePlayedDate { get; set; }
    /// <summary>
    /// The ID of the Home Team
    /// </summary>
    public int HomeTeamId { get; set; }
    /// <summary>
    /// The ID of the Away Team
    /// </summary>
    public int AwayTeamId { get; set; }
    /// <summary>
    /// The Name of the Home Team
    /// </summary>
    public required string HomeTeamName { get; set; }
    /// <summary>
    /// The Name of the Away Team
    /// </summary>
    public required string AwayTeamName { get; set; }
    /// <summary>
    /// The Home Team Score
    /// </summary>
    public int HomeScore { get; set; }
    /// <summary>
    /// The Away Team Score
    /// </summary>
    public int AwayScore { get; set; }
    /// <summary>
    /// The Current Inning of the Game
    /// </summary>
    public int CurrentInning { get; set; }
    /// <summary>
    /// Amount of outs the Home Team has
    /// </summary>
    public int HomeOuts { get; set; }
    /// <summary>
    /// Ammount of outs the Away Team has
    /// </summary>
    public int AwayOuts { get; set; }
    /// <summary>
    /// The completion status of the Game
    /// </summary>
    public bool IsCompleted { get; set; }
    
    /// <summary>
    /// Default constructor
    /// </summary>
    public Game() {}

    /// <summary>
    /// Constructor method to convert a GameDetail into a Game object
    /// </summary>
    /// <param name="detail"></param>
    public Game(GameDetail detail)
    {
        Id = detail.GameId;
        HomeTeamId = detail.HomeTeamId;
        AwayTeamId = detail.AwayTeamId;
        HomeTeamName = detail.HomeTeamName;
        AwayTeamName = detail.AwayTeamName;
        HomeScore = detail.HomeScore;
        AwayScore = detail.AwayScore;
        CurrentInning = detail.CurrentInning;
        HomeOuts = detail.HomeOuts;
        AwayOuts = detail.AwayOuts;
        IsCompleted = detail.IsCompleted;
    }

    /// <summary>
    /// Method to convert a Game object to a GameDetail
    /// </summary>
    /// <returns></returns>
    public GameDetail ToDetail()
    {
        return new GameDetail
        {
            GameId = Id,
            HomeTeamId = HomeTeamId,
            AwayTeamId = AwayTeamId,
            HomeScore = HomeScore,
            AwayScore = AwayScore,
            HomeOuts = HomeOuts,
            AwayOuts = AwayOuts,
            CurrentInning = CurrentInning,
            HomeTeamName = HomeTeamName,
            AwayTeamName = AwayTeamName,
            IsCompleted = IsCompleted,
            GamePlayed = Timestamp.FromDateTime(GamePlayedDate.ToUniversalTime()),
        };
    }
}
