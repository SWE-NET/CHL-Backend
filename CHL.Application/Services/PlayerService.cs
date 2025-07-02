using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;
using CHL.Domain.Simple;
using CHL.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CHL.Application.Services;

public class PlayerService : IPlayerService
{
    private readonly ApplicationDbContext _db;

    public PlayerService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> Create(PlayerDTO model)
    {
        var player = new Player
        {
            Fullname = model.Fullname,
            Dob = model.Dob,
            Position = model.Position,
            Country = model.Country,
            Red_cards = model.Red_cards,
            Yellow_cards = model.Yellow_cards,
            Img = model.Img,
            Overall_goals = model.Overall_goals,
            Price = model.Price,
            Is_injured = model.Is_injured,
            Club_id = model.Club_id,
            Team_id = model.Team_id
        };

        await _db.Players.AddAsync(player);
        await _db.SaveChangesAsync();
        return "Player created successfully";
    }

    public async Task<string> Update(Guid id, PlayerDTO model)
    {
        var player = await _db.Players.FindAsync(id);
        if (player == null) return "Player not found";

        player.Fullname = model.Fullname;
        player.Dob = model.Dob;
        player.Position = model.Position;
        player.Country = model.Country;
        player.Red_cards = model.Red_cards;
        player.Yellow_cards = model.Yellow_cards;
        player.Img = model.Img;
        player.Overall_goals = model.Overall_goals;
        player.Price = model.Price;
        player.Is_injured = model.Is_injured;
        player.Club_id = model.Club_id;
        player.Team_id = model.Team_id;

        await _db.SaveChangesAsync();
        return "Player updated successfully";
    }

    public async Task<string> Delete(Guid id)
    {
        var player = await _db.Players.FindAsync(id);
        if (player == null) return "Player not found";

        _db.Players.Remove(player);
        await _db.SaveChangesAsync();
        return "Player deleted successfully";
    }

    public async Task<PlayerResponseDTO> GetById(Guid id)
    {
        var player = await _db.Players
            .Include(p => p.Club)
            .Include(p => p.Team)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (player == null)
        {
            return null;
        }

        return new PlayerResponseDTO
        {
            Id = player.Id,
            Fullname = player.Fullname,
            Dob = player.Dob,
            Position = player.Position,
            Country = player.Country,
            Red_cards = player.Red_cards,
            Yellow_cards = player.Yellow_cards,
            Img = player.Img,
            Overall_goals = player.Overall_goals,
            Price = player.Price,
            Is_injured = player.Is_injured,
            Club = player.Club != null ? new ClubSimpleDTO
            {
                Id = player.Club.Id,
                Name = player.Club.Name
            } : null,
            Team = player.Team != null ? new TeamSimpleDTO
            {
                Id = player.Team.Id,
                Type = player.Team.Type
            } : null
        };
    }

    public async Task<List<PlayerResponseDTO>> GetAll()
    {
        return await _db.Players
            .Include(p => p.Club)
            .Include(p => p.Team)
            .Select(p => new PlayerResponseDTO
            {
                Id = p.Id,
                Fullname = p.Fullname,
                Dob = p.Dob,
                Position = p.Position,
                Country = p.Country,
                Red_cards = p.Red_cards,
                Yellow_cards = p.Yellow_cards,
                Img = p.Img,
                Overall_goals = p.Overall_goals,
                Price = p.Price,
                Is_injured = p.Is_injured,
                Club = p.Club != null ? new ClubSimpleDTO
                {
                    Id = p.Club.Id,
                    Name = p.Club.Name
                } : null,
                Team = p.Team != null ? new TeamSimpleDTO
                {
                    Id = p.Team.Id,
                    Type = p.Team.Type
                } : null
            })
            .ToListAsync();
    }
}