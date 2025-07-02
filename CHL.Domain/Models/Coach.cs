namespace CHL.Domain.Models;

public class Coach
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Fullname { get; set; }
    public string Dob { get; set; }
    public string Nation { get; set; }
    public int Experience { get; set; } = 0;
    public string Img { get; set; }

    public Guid Club_id { get; set; }
    public Club Club { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();
    public List<Game> Games { get; set; } = new List<Game>();
    public List<News> NewsList { get; set; } = new List<News>();
}