namespace CHL.Domain.Models;

public class Team
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Type { get; set; }
    public string Goals { get; set; }
    
    public Guid CoachId { get; set; }
    public Coach Coach { get; set; }
    
    public Guid ClubId { get; set; }
    public Club Club { get; set; }

    public List<Game> GamesAsTeam1 { get; set; } = new List<Game>();
    public List<Game> GamesAsTeam2 { get; set; } = new List<Game>();
    public List<Player> Players { get; set; } = new List<Player>();
}