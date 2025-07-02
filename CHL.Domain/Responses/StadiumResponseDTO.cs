using CHL.Domain.Simple;

namespace CHL.Domain.Responses;

public class StadiumResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public string Country { get; set; }
    public string Img { get; set; }
    public string Dob { get; set; }
    
    public ClubSimpleDTO Club { get; set; }
}