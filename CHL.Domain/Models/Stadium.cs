namespace CHL.Domain.Models;

public class Stadium
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int Size { get; set; }
    public string Country { get; set; }
    public string Img { get; set; }
    public string Dob { get; set; }
    
    public Guid Club_id { get; set; }
    public Club Club { get; set; }

    public List<Game> Games { get; set; } = new List<Game>();
    public List<News> NewsList { get; set; } = new List<News>();
}