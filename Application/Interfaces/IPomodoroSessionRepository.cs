using Domain.Entities;

namespace Application.Interfaces;

public interface IPomodoroSessionRepository
{
    Task<Guid> CreateSessionAsync(PomodoroSession session, CancellationToken cancellationToken);
    Task<PomodoroSession?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(PomodoroSession session, CancellationToken cancellationToken);
    Task<List<PomodoroSession>> GetAllAsync(CancellationToken cancellationToken);

}