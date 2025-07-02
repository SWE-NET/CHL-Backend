namespace CHL.Domain.DTOs;

public class CoachDTO
{
    public string Fullname { get; set; }
    public string Dob { get; set; }
    public string Nation { get; set; }
    public int Experience { get; set; } = 0;
    public string Img { get; set; }
    public Guid Club_id { get; set; }
}