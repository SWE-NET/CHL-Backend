using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;
using CHL.Domain.Simple;
using CHL.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CHL.Application.Services;

public class CoachService : ICoachService
{

    private readonly ApplicationDbContext _db;

    public CoachService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> Create(CoachDTO model)
    {
        var newCoach = new Coach
        {
            Fullname = model.Fullname,
            Dob = model.Dob,
            Nation = model.Nation,
            Experience = model.Experience,
            Img = model.Img,
            Club_id = model.Club_id
        };

        await _db.Coaches.AddAsync(newCoach);
        await _db.SaveChangesAsync();

        return "Data Created!";
    }

    public async Task<string> Update(Guid id, CoachDTO model)
    {
        var coach = await _db.Coaches.FindAsync(id);

        if (coach == null)
        {
            return null;
        }
        
        coach.Fullname = model.Fullname;
        coach.Dob = model.Dob;
        coach.Nation = model.Nation;
        coach.Experience = model.Experience;
        coach.Img = model.Img;

        await _db.SaveChangesAsync();

        return "Data Updated!";
    }

    public async Task<string> Delete(Guid id)
    {
        var coach = await _db.Coaches.FindAsync(id);

        if (coach == null)
        {
            return null;
        }

        _db.Remove(coach);
        await _db.SaveChangesAsync();

        return "Data Deleted!";
    }

    public async Task<CoachResponseDTO> GetById(Guid id)
    {
        var coach = await _db.Coaches
            .Include(c => c.Club)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (coach == null)
        {
            return null;
        }

        return new CoachResponseDTO
        {
            Id = coach.Id,
            Fullname = coach.Fullname,
            Dob = coach.Dob,
            Nation = coach.Nation,
            Experience = coach.Experience,
            Img = coach.Img,
            Club = coach.Club != null ? new ClubSimpleDTO
            {
                Id = coach.Club.Id,
                Name = coach.Club.Name
            } : null
        };
    }

    public async Task<List<CoachResponseDTO>> GetAll()
    {
        return await _db.Coaches
            .Include(c => c.Club)
            .Select(c => new CoachResponseDTO
            {
                Id = c.Id,
                Fullname = c.Fullname,
                Dob = c.Dob,
                Nation = c.Nation,
                Experience = c.Experience,
                Img = c.Img,
                Club = c.Club != null ? new ClubSimpleDTO
                {
                    Id = c.Club.Id,
                    Name = c.Club.Name,
                    Instagram = c.Club.Instagram
                } : null
            })
            .ToListAsync();
    }
}