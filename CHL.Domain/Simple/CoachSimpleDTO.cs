namespace CHL.Domain.Simple;

public class CoachSimpleDTO
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public string Dob { get; set; }
    public string Nation { get; set; }
    public int Experience { get; set; } = 0;
    public string Img { get; set; }
}