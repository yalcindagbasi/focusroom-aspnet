namespace Application.Queries;

using MediatR;
using Domain.Entities;

public record GetAllPomodoroSessionsQuery : IRequest<List<PomodoroSession>>;