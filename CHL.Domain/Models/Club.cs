namespace CHL.Domain.Models;

public class Club
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Dob { get; set; }
    public string Nation { get; set; }
    public string Logo { get; set; }
    public string Instagram { get; set; }
    public string Twitter { get; set; }
    public string Prezident { get; set; }
    public string Overall_score { get; set; }
    
    public Coach Coach { get; set; }
    public Stadium Stadium { get; set; }
    
    
    public List<Player> Players { get; set; } = new List<Player>();
    public List<News> NewsList { get; set; } = new List<News>();
    public List<Team> Teams { get; set; } = new List<Team>();
    public List<Game> GamesAsClub1 { get; set; } = new List<Game>();
    public List<Game> GamesAsClub2 { get; set; } = new List<Game>();
}