using CHL.Domain.Simple;

namespace CHL.Domain.Responses;

public class GameResponseDTO
{
    public Guid Id { get; set; }
    public string Date { get; set; }
    public string Type { get; set; }
    public int Minutes_added { get; set; } = 0;
    
    public ClubSimpleDTO Club1 { get; set; }
    public ClubSimpleDTO Club2 { get; set; }
    
    public TeamSimpleDTO Team1 { get; set; }
    public TeamSimpleDTO Team2 { get; set; }
    
    public StadiumSimpleDTO Stadium { get; set; }
    
    public RefereeSimpleDTO Referee { get; set; }
}