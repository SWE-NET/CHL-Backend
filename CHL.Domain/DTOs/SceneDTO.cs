namespace CHL.Domain.DTOs;

public class SceneDTO
{
    public string Title { get; set; }
    public string Img { get; set; }
    
    public Guid Game_id { get; set; }
    public Guid Player_id { get; set; }
}