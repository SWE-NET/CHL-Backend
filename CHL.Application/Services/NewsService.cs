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
        };
    }

    public async Task<List<NewsResponseDTO>> GetAll()
    {
        return await _db.News
            .Select(n => new NewsResponseDTO
            {
                Id = n.Id,
                Title = n.Title,
                Text = n.Text,
                Img = n.Img,
                Date = n.Date,
            })
            .ToListAsync();
    }
}