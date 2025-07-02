using CHL.Domain.Simple;

namespace CHL.Domain.Responses;

public class TeamResponseDTO
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Goals { get; set; }
    
    public CoachSimpleDTO Coach { get; set; }
    public ClubSimpleDTO Club { get; set; }
}