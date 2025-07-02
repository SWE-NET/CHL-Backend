using CHL.Domain.DTOs;
using CHL.Domain.Simple;

namespace CHL.Domain.Responses;

public class ClubResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Dob { get; set; }
    public string Nation { get; set; }
    public string Logo { get; set; }
    public string Instagram { get; set; }
    public string Twitter { get; set; }
    public string Prezident { get; set; }
    public string Overall_score { get; set; }
    
    public CoachSimpleDTO Coach { get; set; }
    public StadiumSimpleDTO Stadium { get; set; }
}