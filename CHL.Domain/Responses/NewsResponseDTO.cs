using CHL.Domain.Simple;

namespace CHL.Domain.Responses;

public class NewsResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string Img { get; set; }
    public string Date { get; set; }
    
}