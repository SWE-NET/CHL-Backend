using System.Globalization;
using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;
using CHL.Domain.Simple;
using Microsoft.EntityFrameworkCore;
using CHL.Infrastructure.Persistance;

namespace CHL.Application.Services;

public class GameService : IGameService
{
    private readonly ApplicationDbContext _db;

    public GameService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> Create(GameDTO model)
    {
        if (model == null)
            return "GameDTO cannot be null.";
        
        if (!await _db.Clubs.AnyAsync(c => c.Id == model.Club1Id) ||
            !await _db.Clubs.AnyAsync(c => c.Id == model.Club2Id) ||
            !await _db.Referees.AnyAsync(r => r.Id == model.RefereeId) ||
            !await _db.Stadiums.AnyAsync(s => s.Id == model.StadiumId) ||
            (model.Team1Id.HasValue && !await _db.Teams.AnyAsync(t => t.Id == model.Team1Id)) ||
            (model.Team2Id.HasValue && !await _db.Teams.AnyAsync(t => t.Id == model.Team2Id)))
            return "Invalid foreign key reference.";

        var game = new Game
        {
            Date = Convert.ToString(DateTime.UtcNow, CultureInfo.InvariantCulture),
            Type = model.Type,
            Minutes_added = model.Minutes_added,
            Club1Id = model.Club1Id,
            Club2Id = model.Club2Id,
            Team1Id = model.Team1Id,
            Team2Id = model.Team2Id,
            RefereeId = model.RefereeId,
            StadiumId = model.StadiumId
        };

        _db.Games.Add(game);
        await _db.SaveChangesAsync();
        return "Game created successfully.";
    }

    public async Task<string> Update(Guid id, GameDTO model)
    {
        if (model == null)
            return "GameDTO cannot be null.";

        var game = await _db.Games.FindAsync(id);
        if (game == null)
            return "Game not found.";
        
        if (!await _db.Clubs.AnyAsync(c => c.Id == model.Club1Id) ||
            !await _db.Clubs.AnyAsync(c => c.Id == model.Club2Id) ||
            !await _db.Referees.AnyAsync(r => r.Id == model.RefereeId) ||
            !await _db.Stadiums.AnyAsync(s => s.Id == model.StadiumId) ||
            (model.Team1Id.HasValue && !await _db.Teams.AnyAsync(t => t.Id == model.Team1Id)) ||
            (model.Team2Id.HasValue && !await _db.Teams.AnyAsync(t => t.Id == model.Team2Id)))
            return "Invalid foreign key reference.";
        
        game.Type = model.Type;
        game.Minutes_added = model.Minutes_added;
        game.Club1Id = model.Club1Id;
        game.Club2Id = model.Club2Id;
        game.Team1Id = model.Team1Id;
        game.Team2Id = model.Team2Id;
        game.RefereeId = model.RefereeId;
        game.StadiumId = model.StadiumId;

        await _db.SaveChangesAsync();
        return "Game updated successfully.";
    }

    public async Task<string> Delete(Guid id)
    {
        var game = await _db.Games.FindAsync(id);
        if (game == null)
            return "Game not found.";

        _db.Games.Remove(game);
        await _db.SaveChangesAsync();
        return "Game deleted successfully.";
    }

    public async Task<GameResponseDTO> GetById(Guid id)
    {
        var game = await _db.Games
            .Include(g => g.Club1)
            .Include(g => g.Club2)
            .Include(g => g.Team1)
            .Include(g => g.Team2)
            .Include(g => g.Referee)
            .Include(g => g.Stadium)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (game == null)
        {
            return null;
        }

        return new GameResponseDTO
        {
            Id = game.Id,
            Date = game.Date,
            Type = game.Type,
            Minutes_added = game.Minutes_added,
            Club1 = game.Club1 != null ? new ClubSimpleDTO
            {
                Id = game.Club1.Id,
                Name = game.Club1.Name
            } : null,
            Club2 = game.Club2 != null ? new ClubSimpleDTO
            {
                Id = game.Club2.Id,
                Name = game.Club2.Name
            } : null,
            Team1 = game.Team1 != null ? new TeamSimpleDTO
            {
                Id = game.Team1.Id,
                Type = game.Team1.Type
            } : null,
            Team2 = game.Team2 != null ? new TeamSimpleDTO
            {
                Id = game.Team2.Id,
                Type = game.Team2.Type
            } : null,
            Stadium = game.Stadium != null ? new StadiumSimpleDTO
            {
                Id = game.Stadium.Id,
                Name = game.Stadium.Name
            } : null,
            Referee = game.Referee != null ? new RefereeSimpleDTO
            {
                Id = game.Referee.Id,
                Fullname = game.Referee.Fullname
            } : null
        };
    }

    public async Task<List<GameResponseDTO>> GetAll()
    {
        return await _db.Games
            .Include(g => g.Club1)
            .Include(g => g.Club2)
            .Include(g => g.Team1)
            .Include(g => g.Team2)
            .Include(g => g.Referee)
            .Include(g => g.Stadium)
            .Select(g => new GameResponseDTO
            {
                Id = g.Id,
                Date = g.Date,
                Type = g.Type,
                Minutes_added = g.Minutes_added,
                Club1 = g.Club1 != null ? new ClubSimpleDTO
                {
                    Id = g.Club1.Id,
                    Name = g.Club1.Name
                } : null,
                Club2 = g.Club2 != null ? new ClubSimpleDTO
                {
                    Id = g.Club2.Id,
                    Name = g.Club2.Name
                } : null,
                Team1 = g.Team1 != null ? new TeamSimpleDTO
                {
                    Id = g.Team1.Id,
                    Type = g.Team1.Type
                } : null,
                Team2 = g.Team2 != null ? new TeamSimpleDTO
                {
                    Id = g.Team2.Id,
                    Type = g.Team2.Type
                } : null,
                Stadium = g.Stadium != null ? new StadiumSimpleDTO
                {
                    Id = g.Stadium.Id,
                    Name = g.Stadium.Name
                } : null,
                Referee = g.Referee != null ? new RefereeSimpleDTO
                {
                    Id = g.Referee.Id,
                    Fullname = g.Referee.Fullname
                } : null
            })
            .ToListAsync();
    }
}