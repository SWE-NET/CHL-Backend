using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;
using CHL.Domain.Simple;
using CHL.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CHL.Application.Services;

public class ClubService : IClubService
{
    private readonly ApplicationDbContext _db;

    public ClubService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> Create(ClubDTO model)
    {
        var newClub = new Club
        {
            Name = model.Name,
            Dob = model.Dob,
            Nation = model.Nation,
            Logo = model.Logo,
            Instagram = model.Instagram,
            Twitter = model.Twitter,
            Prezident = model.Prezident,
            Overall_score = model.Overall_score
        };

        await _db.Clubs.AddAsync(newClub);
        await _db.SaveChangesAsync();

        return "Data Created!";
    }

    public async Task<string> Update(Guid id, ClubDTO model)
    {
        var club = await _db.Clubs.FindAsync(id);

        if (club == null)
        {
            return null;
        }
        
        club.Name = model.Name;
        club.Dob = model.Dob;
        club.Nation = model.Nation;
        club.Logo = model.Logo;
        club.Instagram = model.Instagram;
        club.Twitter = model.Twitter;
        club.Prezident = model.Prezident;
        club.Overall_score = model.Overall_score;

        await _db.SaveChangesAsync();

        return "Data Updated!";
    }

    public async Task<string> Delete(Guid id)
    {
        var club = await _db.Clubs.FindAsync(id);

        if (club == null)
        {
            return null;
        }

        _db.Clubs.Remove(club);
        await _db.SaveChangesAsync();

        return "Data Deleted!";
    }

    public async Task<ClubResponseDTO> GetById(Guid id)
    {
        var club = await _db.Clubs
            .Include(c => c.Coach)
            .Include(c => c.Stadium)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (club == null)
        {
            return null;
        }

        return new ClubResponseDTO 
        {
            Id = club.Id,
            Name = club.Name,
            Dob = club.Dob,
            Nation = club.Nation,
            Logo = club.Logo,
            Instagram = club.Instagram,
            Twitter = club.Twitter,
            Prezident = club.Prezident,
            Overall_score = club.Overall_score,
            Coach = club.Coach != null ? new CoachSimpleDTO 
            {
                Id = club.Coach.Id,
                Fullname = club.Coach.Fullname,
                Dob = club.Coach.Dob,
                Nation = club.Coach.Nation,
                Experience = club.Coach.Experience,
                Img = club.Coach.Img
            } : null,
            Stadium = club.Stadium != null ? new StadiumSimpleDTO 
            {
                Id = club.Stadium.Id,
                Name = club.Stadium.Name,
                Size = club.Stadium.Size,
                Country = club.Stadium.Country,
                Img = club.Stadium.Img,
                Dob = club.Stadium.Dob
            } : null
        };
    }

    public async Task<List<ClubResponseDTO>> GetAll()
    {
        return await _db.Clubs
            .Include(c => c.Coach)
            .Include(c => c.Stadium)
            .Select(c => new ClubResponseDTO 
            {
                Id = c.Id,
                Name = c.Name,
                Dob = c.Dob,
                Nation = c.Nation,
                Logo = c.Logo,
                Instagram = c.Instagram,
                Twitter = c.Twitter,
                Prezident = c.Prezident,
                Overall_score = c.Overall_score,
                Coach = c.Coach != null ? new CoachSimpleDTO 
                {
                    Id = c.Coach.Id,
                    Fullname = c.Coach.Fullname
                } : null,
                Stadium = c.Stadium != null ? new StadiumSimpleDTO 
                {
                    Id = c.Stadium.Id,
                    Name = c.Stadium.Name
                } : null
            })
            .ToListAsync();
    }
}