using System.Text;
using CHL.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CHL.Infrastructure.Persistance;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Stadium> Stadiums { get; set; }
    public DbSet<Scene> Scenes { get; set; }
    public DbSet<Referee> Referees { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Club> Clubs { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        
        modelBuilder.Entity<Team>()
            .HasOne(t => t.Coach)
            .WithMany(c => c.Teams)
            .HasForeignKey(t => t.CoachId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Team>()
            .HasOne(t => t.Club)
            .WithMany(c => c.Teams)
            .HasForeignKey(t => t.ClubId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Stadium>()
            .HasOne(s => s.Club)
            .WithOne(c => c.Stadium)
            .HasForeignKey<Stadium>(s => s.Club_id)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Scene>()
            .HasOne(s => s.Game)
            .WithMany(g => g.Scenes)
            .HasForeignKey(s => s.Game_id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Scene>()
            .HasOne(s => s.Player)
            .WithMany(p => p.Scenes)
            .HasForeignKey(s => s.Player_id)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Referee>()
            .HasMany(r => r.Games)
            .WithOne(g => g.Referee)
            .HasForeignKey(g => g.RefereeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Player>()
            .HasOne(p => p.Club)
            .WithMany(c => c.Players)
            .HasForeignKey(p => p.Club_id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Player>()
            .HasOne(p => p.Team)
            .WithMany(t => t.Players)
            .HasForeignKey(p => p.Team_id)
            .OnDelete(DeleteBehavior.Restrict);
        
        // modelBuilder.Entity<News>()
        //     .HasOne(n => n.Club)
        //     .WithMany(c => c.NewsList)
        //     .HasForeignKey(n => n.Club_id)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // modelBuilder.Entity<News>()
        //     .HasOne(n => n.Player)
        //     .WithMany(p => p.NewsList)
        //     .HasForeignKey(n => n.Player_id)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // modelBuilder.Entity<News>()
        //     .HasOne(n => n.Coach)
        //     .WithMany(c => c.NewsList)
        //     .HasForeignKey(n => n.Coach_id)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // modelBuilder.Entity<News>()
        //     .HasOne(n => n.Game)
        //     .WithMany(g => g.NewsList)
        //     .HasForeignKey(n => n.Game_id)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // modelBuilder.Entity<News>()
        //     .HasOne(n => n.Referee)
        //     .WithMany(r => r.NewsList)
        //     .HasForeignKey(n => n.Referee_id)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // modelBuilder.Entity<News>()
        //     .HasOne(n => n.Stadium)
        //     .WithMany(s => s.NewsList)
        //     .HasForeignKey(n => n.Stadium_id)
        //     .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Referee)
            .WithMany(r => r.Games)
            .HasForeignKey(g => g.RefereeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Stadium)
            .WithMany(s => s.Games)
            .HasForeignKey(g => g.StadiumId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Team1)
            .WithMany(t => t.GamesAsTeam1)
            .HasForeignKey(g => g.Team1Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Team2)
            .WithMany(t => t.GamesAsTeam2)
            .HasForeignKey(g => g.Team2Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Club1)
            .WithMany(c => c.GamesAsClub1)
            .HasForeignKey(g => g.Club1Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Club2)
            .WithMany(c => c.GamesAsClub2)
            .HasForeignKey(g => g.Club2Id)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Club>()
            .HasOne(c => c.Coach)
            .WithOne(c => c.Club)
            .HasForeignKey<Coach>(c => c.Club_id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Club>()
            .HasOne(c => c.Stadium)
            .WithOne(s => s.Club)
            .HasForeignKey<Stadium>(s => s.Club_id)
            .OnDelete(DeleteBehavior.Restrict);
        
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(ToSnakeCase(property.Name));
            }
        }
    }

    private string ToSnakeCase(string input)
    {
        if (string.IsNullOrEmpty(input)) { return input; }

        var builder = new StringBuilder();
        builder.Append(char.ToLowerInvariant(input[0]));

        for (int i = 1; i < input.Length; i++)
        {
            if (char.IsUpper(input[i]))
            {
                builder.Append('_');
                builder.Append(char.ToLowerInvariant(input[i]));
            }
            else
            {
                builder.Append(input[i]);
            }
        }

        return builder.ToString();
    }
}