using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CHL.Application.Services;

public class RefereeService : IRefereeService
{
    private readonly ApplicationDbContext _db;

    public RefereeService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> Create(RefereeDTO model)
    {
        var referee = new Referee
        {
            Fullname = model.Fullname,
            Experience = model.Experience,
            Country = model.Country,
            Img = model.Img
        };

        await _db.Referees.AddAsync(referee);
        await _db.SaveChangesAsync();
        return "Referee created successfully";
    }

    public async Task<string> Update(Guid id, RefereeDTO model)
    {
        var referee = await _db.Referees.FindAsync(id);
        if (referee == null) return "Referee not found";

        referee.Fullname = model.Fullname;
        referee.Experience = model.Experience;
        referee.Country = model.Country;
        referee.Img = model.Img;

        await _db.SaveChangesAsync();
        return "Referee updated successfully";
    }

    public async Task<string> Delete(Guid id)
    {
        var referee = await _db.Referees.FindAsync(id);
        if (referee == null) return "Referee not found";

        _db.Referees.Remove(referee);
        await _db.SaveChangesAsync();
        return "Referee deleted successfully";
    }

    public async Task<Referee> GetById(Guid id)
    {
        return await _db.Referees
            .Include(r => r.Games)
            .Include(r => r.NewsList)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Referee>> GetAll()
    {
        return await _db.Referees
            .Include(r => r.Games)
            .ToListAsync();
    }
}