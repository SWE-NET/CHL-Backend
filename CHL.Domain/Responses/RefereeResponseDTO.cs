using CHL.Domain.Simple;

namespace CHL.Domain.Responses;

public class RefereeResponseDTO
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public int Experience { get; set; }
    public string Country { get; set; }
    public string Img { get; set; }
    public List<GameSimpleDTO> Games { get; set; }
}