using System.Globalization;
using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Domain.Responses;
using CHL.Domain.Simple;
using CHL.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CHL.Application.Services;

public class NewsService : INewsService
{
    private readonly ApplicationDbContext _db;

    public NewsService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<string> Create(NewsDTO model)
    {
        var news = new News
        {
            Date = Convert.ToString(DateTime.UtcNow, CultureInfo.InvariantCulture),
            Title = model.Title,
            Text = model.Text,
            Img = model.Img,
            Club_id = model.Club_id,
            Player_id = model.Player_id,
            Coach_id = model.Coach_id,
            Game_id = model.Game_id,
            Referee_id = model.Referee_id,
            Stadium_id = model.Stadium_id
        };

        await _db.News.AddAsync(news);
        await _db.SaveChangesAsync();
        return "News created successfully";
    }

    public async Task<string> Update(Guid id, NewsDTO model)
    {
        var news = await _db.News.FindAsync(id);
        if (news == null) return "News not found";

        news.Title = model.Title;
        news.Text = model.Text;
        news.Img = model.Img;
        news.Club_id = model.Club_id;
        news.Player_id = model.Player_id;
        news.Coach_id = model.Coach_id;
        news.Game_id = model.Game_id;
        news.Referee_id = model.Referee_id;
        news.Stadium_id = model.Stadium_id;

        await _db.SaveChangesAsync();
        return "News updated successfully";
    }

    public async Task<string> Delete(Guid id)
    {
        var news = await _db.News.FindAsync(id);
        if (news == null) return "News not found";

        _db.News.Remove(news);
        await _db.SaveChangesAsync();
        return "News deleted successfully";
    }

    public async Task<NewsResponseDTO> GetById(Guid id)
    {
        var news = await _db.News
            .Include(n => n.Club)
            .Include(n => n.Player)
            .Include(n => n.Coach)
            .Include(n => n.Game)
            .Include(n => n.Referee)
            .Include(n => n.Stadium)
            .FirstOrDefaultAsync(n => n.Id == id);

        if (news == null)
        {
            return null;
        }

        return new NewsResponseDTO
        {
            Id = news.Id,
            Title = news.Title,
            Text = news.Text,
            Img = news.Img,
            Date = news.Date,
            Player = news.Player != null ? new PlayerSimpleDTO
            {
                Id = news.Player.Id,
                Fullname = news.Player.Fullname
            } : null,
            Referee = news.Referee != null ? new RefereeSimpleDTO
            {
                Id = news.Referee.Id,
                Fullname = news.Referee.Fullname
            } : null,
            Stadium = news.Stadium != null ? new StadiumSimpleDTO
            {
                Id = news.Stadium.Id,
                Name = news.Stadium.Name
            } : null,
            Coach = news.Coach != null ? new CoachSimpleDTO
            {
                Id = news.Coach.Id,
                Fullname = news.Coach.Fullname
            } : null,
            Game = news.Game != null ? new GameSimpleDTO
            {
                Id = news.Game.Id,
                Date = news.Game.Date
            } : null
        };
    }

    public async Task<List<NewsResponseDTO>> GetAll()
    {
        return await _db.News
            .Include(n => n.Club)
            .Include(n => n.Player)
            .Include(n => n.Coach)
            .Include(n => n.Game)
            .Include(n => n.Referee)
            .Include(n => n.Stadium)
            .Select(n => new NewsResponseDTO
            {
                Id = n.Id,
                Title = n.Title,
                Text = n.Text,
                Img = n.Img,
                Date = n.Date,
                Player = n.Player != null ? new PlayerSimpleDTO
                {
                    Id = n.Player.Id,
                    Fullname = n.Player.Fullname
                } : null,
                Referee = n.Referee != null ? new RefereeSimpleDTO
                {
                    Id = n.Referee.Id,
                    Fullname = n.Referee.Fullname
                } : null,
                Stadium = n.Stadium != null ? new StadiumSimpleDTO
                {
                    Id = n.Stadium.Id,
                    Name = n.Stadium.Name
                } : null,
                Coach = n.Coach != null ? new CoachSimpleDTO
                {
                    Id = n.Coach.Id,
                    Fullname = n.Coach.Fullname
                } : null,
                Game = n.Game != null ? new GameSimpleDTO
                {
                    Id = n.Game.Id,
                    Date = n.Game.Date
                } : null
            })
            .ToListAsync();
    }
}