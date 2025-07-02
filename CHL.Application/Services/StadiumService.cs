using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;
using CHL.Domain.Simple;
using CHL.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CHL.Application.Services;

public class StadiumService : IStadiumService
{
    private readonly ApplicationDbContext _db;

    public StadiumService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> Create(StadiumDTO model)
    {
        var stadium = new Stadium
        {
            Name = model.Name,
            Size = model.Size,
            Country = model.Country,
            Img = model.Img,
            Dob = model.Dob,
            Club_id = model.Club_id
        };

        await _db.Stadiums.AddAsync(stadium);
        await _db.SaveChangesAsync();
        return "Stadium created successfully";
    }

    public async Task<string> Update(Guid id, StadiumDTO model)
    {
        var stadium = await _db.Stadiums.FindAsync(id);
        if (stadium == null) return "Stadium not found";

        stadium.Name = model.Name;
        stadium.Size = model.Size;
        stadium.Country = model.Country;
        stadium.Img = model.Img;
        stadium.Dob = model.Dob;
        stadium.Club_id = model.Club_id;

        await _db.SaveChangesAsync();
        return "Stadium updated successfully";
    }

    public async Task<string> Delete(Guid id)
    {
        var stadium = await _db.Stadiums.FindAsync(id);
        if (stadium == null) return "Stadium not found";

        _db.Stadiums.Remove(stadium);
        await _db.SaveChangesAsync();
        return "Stadium deleted successfully";
    }

    public async Task<StadiumResponseDTO> GetById(Guid id)
    {
        var stadium = await _db.Stadiums
            .Include(s => s.Club)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (stadium == null)
        {
            return null;
        }

        return new StadiumResponseDTO
        {
            Id = stadium.Id,
            Name = stadium.Name,
            Size = stadium.Size,
            Country = stadium.Country,
            Img = stadium.Img,
            Dob = stadium.Dob,
            Club = stadium.Club != null ? new ClubSimpleDTO
            {
                Id = stadium.Club.Id,
                Name = stadium.Club.Name
            } : null
        };
    }

    public async Task<List<StadiumResponseDTO>> GetAll()
    {
        return await _db.Stadiums
            .Include(s => s.Club)
            .Select(s => new StadiumResponseDTO
            {
                Id = s.Id,
                Name = s.Name,
                Size = s.Size,
                Country = s.Country,
                Img = s.Img,
                Dob = s.Dob,
                Club = s.Club != null ? new ClubSimpleDTO
                {
                    Id = s.Club.Id,
                    Name = s.Club.Name
                } : null
            })
            .ToListAsync();
    }
}