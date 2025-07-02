namespace CHL.Domain.DTOs;

public class GameDTO
{
    public string Date { get; set; }
    public string Type { get; set; }
    public int Minutes_added { get; set; } = 0;
    
    public Guid Club1Id { get; set; }
    
    public Guid Club2Id { get; set; }
    
    public Guid? Team1Id { get; set; } 
    
    public Guid? Team2Id { get; set; } 
    
    public Guid RefereeId { get; set; }
    
    public Guid StadiumId { get; set; }
}