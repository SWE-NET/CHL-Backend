using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CHL.Application.Abstractions;
using CHL.Domain.DTOs;
using CHL.Domain.Models;
using CHL.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CHL.Application.Services;

public class JWTService : IJWTService
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly ApplicationDbContext _db;

    public JWTService(IConfiguration configuration, IUserService userService, ApplicationDbContext db)
    {
        _configuration = configuration;
        _userService = userService;
        _db = db;
    }

    public async Task<ResponseDTO> Login(LoginDTO model)
    {
        var user = await _db.Users.FirstOrDefaultAsync(
            u => u.Email == model.Email);

        if (user == null)
        {
            return new ResponseDTO
            {
                Token = "null",
                Message = "Bunday emailda foydalanuvchi ro'yhatdan o'tmagan",
                Code = 404
            };
        }
        
        else if (BCrypt.Net.BCrypt.EnhancedVerify(model.Password, user.Password))
        {
            var token = GenerateToken(user);

            return new ResponseDTO
            {
                Token = token,
                Message = "Siz muvaffaqqiyatli accountga o'tdingiz!",
                Code = 201
            };
        }

        return new ResponseDTO
        {
            Token = "null",
            Message = "Parol xato",
            Code = 404
        };
    }

    public async Task<string> Register(UserDTO model)
    {
        return await _userService.Create(model);
    }
    
    private string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:ExpireHours"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}