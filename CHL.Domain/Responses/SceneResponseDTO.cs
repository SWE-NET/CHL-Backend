using CHL.Domain.Simple;

namespace CHL.Domain.Responses;

public class SceneResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Img { get; set; }
    
    public GameSimpleDTO Game { get; set; }
    public PlayerSimpleDTO Player { get; set; }
}