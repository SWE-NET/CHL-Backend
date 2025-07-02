using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;
using CHL.Domain.Simple;
using CHL.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CHL.Application.Services;

public class SceneService : ISceneService
{
    private readonly ApplicationDbContext _db;

    public SceneService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> Create(SceneDTO model)
    {
        var scene = new Scene
        {
            Title = model.Title,
            Img = model.Img,
            Game_id = model.Game_id,
            Player_id = model.Player_id
        };

        await _db.Scenes.AddAsync(scene);
        await _db.SaveChangesAsync();
        return "Scene created successfully";
    }

    public async Task<string> Update(Guid id, SceneDTO model)
    {
        var scene = await _db.Scenes.FindAsync(id);
        if (scene == null) return "Scene not found";

        scene.Title = model.Title;
        scene.Img = model.Img;
        scene.Game_id = model.Game_id;
        scene.Player_id = model.Player_id;

        await _db.SaveChangesAsync();
        return "Scene updated successfully";
    }

    public async Task<string> Delete(Guid id)
    {
        var scene = await _db.Scenes.FindAsync(id);
        if (scene == null) return "Scene not found";

        _db.Scenes.Remove(scene);
        await _db.SaveChangesAsync();
        return "Scene deleted successfully";
    }

    public async Task<SceneResponseDTO> GetById(Guid id)
    {
        var scene = await _db.Scenes
            .Include(s => s.Game)
            .Include(s => s.Player)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (scene == null)
        {
            return null;
        }

        return new SceneResponseDTO
        {
            Id = scene.Id,
            Title = scene.Title,
            Img = scene.Img,
            Game = scene.Game != null ? new GameSimpleDTO
            {
                Id = scene.Game.Id,
                Date = scene.Game.Date
            } : null,
            Player = scene.Player != null ? new PlayerSimpleDTO
            {
                Id = scene.Player.Id,
                Fullname = scene.Player.Fullname
            } : null
        };
    }

    public async Task<List<SceneResponseDTO>> GetAll()
    {
        return await _db.Scenes
            .Include(s => s.Game)
            .Include(s => s.Player)
            .Select(s => new SceneResponseDTO
            {
                Id = s.Id,
                Title = s.Title,
                Img = s.Img,
                Game = s.Game != null ? new GameSimpleDTO
                {
                    Id = s.Game.Id,
                    Date = s.Game.Date
                } : null,
                Player = s.Player != null ? new PlayerSimpleDTO
                {
                    Id = s.Player.Id,
                    Fullname = s.Player.Fullname
                } : null
            })
            .ToListAsync();
    }
}