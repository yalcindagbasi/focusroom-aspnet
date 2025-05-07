using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Persistence;

public class PomodoroSessionRepository : IPomodoroSessionRepository
{
    private readonly AppDbContext _context;

    public PomodoroSessionRepository(AppDbContext context) => _context = context;

    public async Task<Guid> CreateSessionAsync(PomodoroSession session, CancellationToken cancellationToken)
    {
        _context.PomodoroSessions.Add(session);
        await _context.SaveChangesAsync(cancellationToken);
        return session.Id;
    }

    public async Task<PomodoroSession?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.PomodoroSessions.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task UpdateAsync(PomodoroSession session, CancellationToken cancellationToken)
    {
        _context.PomodoroSessions.Update(session);
        await _context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<List<PomodoroSession>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.PomodoroSessions.ToListAsync(cancellationToken);
    }
}