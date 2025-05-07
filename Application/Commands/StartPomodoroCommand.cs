namespace Application.Commands;
using MediatR;

public record StartPomodoroCommand(int DurationInMinutes) : IRequest<Guid>;
