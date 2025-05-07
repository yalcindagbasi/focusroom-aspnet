using Application.Commands;

namespace Application.Handlers;

// Application/Handlers/StopPomodoroCommandHandler.cs
using MediatR;
using Application.Interfaces;
using Domain.Entities;

public class StopPomodoroCommandHandler : IRequestHandler<StopPomodoroCommand, Unit>
{
    private readonly IPomodoroSessionRepository _repository;

    public StopPomodoroCommandHandler(IPomodoroSessionRepository repository)
        => _repository = repository;

    public async Task<Unit> Handle(StopPomodoroCommand request, CancellationToken cancellationToken)
    {
        var session = await _repository.GetByIdAsync(request.SessionId, cancellationToken);
        if (session is null)
            throw new KeyNotFoundException("Session not found");

        session.EndTime = DateTime.UtcNow;
        await _repository.UpdateAsync(session, cancellationToken);

        return Unit.Value;
    }
}