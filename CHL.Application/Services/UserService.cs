using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CHL.Application.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _db;

    public UserService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> Create(UserDTO model)
    {
        var user = new User
        {
            Fullname = model.Fullname,
            Dob = model.Dob,
            Phone = model.Phone,
            Location = model.Location,
            Email = model.Email,
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword(model.Password)
        };

        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
        return "User created successfully";
    }

    public async Task<string> Update(Guid id, UserDTO model)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null) return "User not found";

        user.Fullname = model.Fullname;
        user.Dob = model.Dob;
        user.Phone = model.Phone;
        user.Location = model.Location;
        user.Email = model.Email;

        await _db.SaveChangesAsync();
        return "User updated successfully";
    }

    public async Task<string> Delete(Guid id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null) return "User not found";

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return "User deleted successfully";
    }

    public async Task<User> GetById(Guid id)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<User>> GetAll()
    {
        return await _db.Users.ToListAsync();
    }
}