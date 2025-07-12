namespace CHL.Domain.Models;

public class News
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Text { get; set; }
    public string Img { get; set; }
    public string Date { get; set; }
}