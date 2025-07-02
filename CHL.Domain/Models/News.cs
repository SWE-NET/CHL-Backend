namespace CHL.Domain.Models;

public class News
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Text { get; set; }
    public string Img { get; set; }
    public string Date { get; set; }


    public Guid? Club_id { get; set; }
    public Club Club { get; set; }
    
    public Guid Player_id { get; set; }
    public Player Player { get; set; }
    
    public Guid Coach_id { get; set; }
    public Coach Coach { get; set; }
    
    public Guid Game_id { get; set; }
    public Game Game { get; set; }
    
    public Guid Referee_id { get; set; }
    public Referee Referee { get; set; }
    
    public Guid Stadium_id { get; set; }
    public Stadium Stadium { get; set; }
}