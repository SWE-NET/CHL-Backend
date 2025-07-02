using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;
using CHL.Domain.Simple;
using CHL.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CHL.Application.Services;

public class TeamService : ITeamService
{
    private readonly ApplicationDbContext _db;

    public TeamService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> Create(TeamDTO model)
    {
        var team = new Team
        {
            Type = model.Type,
            Goals = model.Goals,
            CoachId = model.Coach_id,
            ClubId = model.Club_id
        };

        await _db.Teams.AddAsync(team);
        await _db.SaveChangesAsync();
        return "Team created successfully";
    }

    public async Task<string> Update(Guid id, TeamDTO model)
    {
        var team = await _db.Teams.FindAsync(id);
        if (team == null) return "Team not found";

        team.Type = model.Type;
        team.Goals = model.Goals;
        team.CoachId = model.Coach_id;
        team.ClubId = model.Club_id;

        await _db.SaveChangesAsync();
        return "Team updated successfully";
    }

    public async Task<string> Delete(Guid id)
    {
        var team = await _db.Teams.FindAsync(id);
        if (team == null) return "Team not found";

        _db.Teams.Remove(team);
        await _db.SaveChangesAsync();
        return "Team deleted successfully";
    }

    public async Task<TeamResponseDTO> GetById(Guid id)
    {
        var team = await _db.Teams
            .Include(t => t.Coach)
            .Include(t => t.Club)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (team == null)
        {
            return null;
        }

        return new TeamResponseDTO
        {
            Id = team.Id,
            Type = team.Type,
            Goals = team.Goals,
            Coach = team.Coach != null ? new CoachSimpleDTO
            {
                Id = team.Coach.Id,
                Fullname = team.Coach.Fullname
            } : null,
            Club = team.Club != null ? new ClubSimpleDTO
            {
                Id = team.Club.Id,
                Name = team.Club.Name
            } : null
        };
    }

    public async Task<List<TeamResponseDTO>> GetAll()
    {
        return await _db.Teams
            .Include(t => t.Coach)
            .Include(t => t.Club)
            .Select(t => new TeamResponseDTO
            {
                Id = t.Id,
                Type = t.Type,
                Goals = t.Goals,
                Coach = t.Coach != null ? new CoachSimpleDTO
                {
                    Id = t.Coach.Id,
                    Fullname = t.Coach.Fullname
                } : null,
                Club = t.Club != null ? new ClubSimpleDTO
                {
                    Id = t.Club.Id,
                    Name = t.Club.Name
                } : null
            })
            .ToListAsync();
    }
}