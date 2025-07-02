using CHL.Domain.Simple;

namespace CHL.Domain.Responses;

public class NewsResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string Img { get; set; }
    public string Date { get; set; }
    
    public PlayerSimpleDTO Player { get; set; }
    public RefereeSimpleDTO Referee { get; set; }
    public StadiumSimpleDTO Stadium { get; set; }
    public CoachSimpleDTO Coach { get; set; }
    public GameSimpleDTO Game { get; set; }
}