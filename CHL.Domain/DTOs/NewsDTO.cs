namespace CHL.Domain.DTOs;

public class NewsDTO
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string Img { get; set; }
    public string Date { get; set; }
    
    public Guid Club_id { get; set; }
    public Guid Player_id { get; set; }
    public Guid Coach_id { get; set; }
    public Guid Game_id { get; set; }
    public Guid Referee_id { get; set; }
    public Guid Stadium_id { get; set; }
}