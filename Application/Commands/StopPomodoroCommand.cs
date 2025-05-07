namespace Application.Commands;

using MediatR;

public record StopPomodoroCommand(Guid SessionId) : IRequest<Unit>;
