using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IAuthService _auth;

    public AuthController(AppDbContext db, IAuthService auth)
    {
        _db = db;
        _auth = auth;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (_db.Users.Any(u => u.Username == request.Username))
            return BadRequest("Username already taken");

        var user = new User
        {
            Username = request.Username,
            PasswordHash = _auth.HashPassword(request.Password)
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user is null || !_auth.VerifyPassword(user.PasswordHash, request.Password))
            return Unauthorized("Invalid credentials");

        var token = _auth.GenerateToken(user);
        return Ok(new { token });
    }
}

public record RegisterRequest(string Username, string Password);
public record LoginRequest(string Username, string Password);