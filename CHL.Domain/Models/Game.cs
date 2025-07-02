namespace CHL.Domain.Models;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Date { get; set; }
    public string Type { get; set; }
    public int Minutes_added { get; set; } = 0;
    
    public Guid Club1Id { get; set; }
    public Club Club1 { get; set; }
    
    public Guid Club2Id { get; set; }
    public Club Club2 { get; set; }
    
    public Guid? Team1Id { get; set; } 
    public Team Team1 { get; set; }
    
    public Guid? Team2Id { get; set; } 
    public Team Team2 { get; set; }
    
    public Guid RefereeId { get; set; }
    public Referee Referee { get; set; }
    
    public Guid StadiumId { get; set; }
    public Stadium Stadium { get; set; }

    public List<Player> GoalScorers { get; set; } = new List<Player>();
    public List<News> NewsList { get; set; } = new List<News>();
    public List<Scene> Scenes { get; set; } = new List<Scene>();
}