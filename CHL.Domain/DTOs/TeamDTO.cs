namespace CHL.Domain.DTOs;

public class TeamDTO
{
    public string Type { get; set; }
    public string Goals { get; set; }
    
    public Guid Coach_id { get; set; }
    public Guid Club_id { get; set; }
}