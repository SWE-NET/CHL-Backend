namespace CHL.Domain.Models;

public class Scene
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Img { get; set; }
    
    public Guid Game_id { get; set; }
    public Game Game { get; set; }
    
    public Guid Player_id { get; set; }
    public Player Player { get; set; }
}