namespace CHL.Domain.DTOs;

public class StadiumDTO
{
    public string Name { get; set; }
    public int Size { get; set; }
    public string Country { get; set; }
    public string Img { get; set; }
    public string Dob { get; set; }
    
    public Guid Club_id { get; set; }
}