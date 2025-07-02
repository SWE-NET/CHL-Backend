namespace CHL.Domain.Models;

public class Player
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Fullname { get; set; }
    public string Dob { get; set; }
    public string Position { get; set; }
    public string Country { get; set; }
    public int Red_cards { get; set; } = 0;
    public int Yellow_cards { get; set; } = 0;
    public string Img { get; set; }
    public int Overall_goals { get; set; }
    public string Price { get; set; }
    public bool Is_injured { get; set; } = false;
    
    public Guid Club_id { get; set; }
    public Club Club { get; set; }
    
    public Guid Team_id { get; set; }
    public Team Team { get; set; }
    
    public List<News> NewsList { get; set; } = new List<News>();
    public List<Scene> Scenes { get; set; } = new List<Scene>();
}