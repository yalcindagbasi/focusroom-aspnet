namespace Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Domain.Entities;

public class AppDbContext : DbContext
{
    public DbSet<PomodoroSession> PomodoroSessions => Set<PomodoroSession>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}