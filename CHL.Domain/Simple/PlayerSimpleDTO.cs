namespace CHL.Domain.Simple;

public class PlayerSimpleDTO
{
    public Guid Id { get; set; }
    public string Fullname { get; set; }
    public string Dob { get; set; }
    public string Position { get; set; }
    public string Country { get; set; }
    public int Red_cards { get; set; } = 0;
    public int Yellow_cards { get; set; } = 0;
    public string Img { get; set; }
    public int Overall_goals { get; set; }
    public string Price { get; set; }
    public bool Is_injured { get; set; } = false;
}