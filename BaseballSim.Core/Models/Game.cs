namespace BaseballSim.Core.Models;

public class Game
{
    public int Id { get; set; }
    public DateTime GamePlayedDate { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public string HomeTeamName { get; set; }
    public string AwayTeamName { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public int CurrentInning { get; set; }
    public int HomeOuts { get; set; }
    public int AwayOuts { get; set; }
    public bool IsCompleted { get; set; }
}