namespace CHL.Domain.Models;

public class Referee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Fullname { get; set; }
    public int Experience { get; set; }
    public string Country { get; set; }
    public string Img { get; set; }

    public List<Game> Games { get; set; } = new List<Game>();
    public List<News> NewsList { get; set; } = new List<News>();
}