using Application.Commands;

namespace Application.Handlers;

using MediatR;
using Domain.Entities;
using Interfaces;

public class StartPomodoroCommandHandler : IRequestHandler<StartPomodoroCommand, Guid>
{
    private readonly IPomodoroSessionRepository _repository;

    public StartPomodoroCommandHandler(IPomodoroSessionRepository repository)
        => _repository = repository;

    public async Task<Guid> Handle(StartPomodoroCommand request, CancellationToken cancellationToken)
    {
        var session = new PomodoroSession
        {
            Id = Guid.NewGuid(),
            StartTime = DateTime.UtcNow,
            DurationInMinutes = request.DurationInMinutes
        };

        await _repository.CreateSessionAsync(session, cancellationToken);
        return session.Id;
    }
}