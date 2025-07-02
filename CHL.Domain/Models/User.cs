namespace CHL.Domain.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Fullname { get; set; }
    public string Dob { get; set; }
    public string Phone { get; set; }
    public string Location { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}