namespace CHL.Domain.Simple;

public class GameSimpleDTO
{
    public Guid Id { get; set; }
    public string Date { get; set; }
    public string Type { get; set; }
    public int Minutes_added { get; set; } = 0;
}