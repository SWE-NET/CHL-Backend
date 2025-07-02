using System.Globalization;

namespace CHL.Domain.DTOs;

public class ResponseDTO
{
    public string? Token { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
    public string Date { get; set; } = Convert.ToString(DateTime.UtcNow, CultureInfo.InvariantCulture);
}