using Application.Queries;

namespace Application.Handlers;

using MediatR;
using Application.Interfaces;
using Domain.Entities;

public class GetAllPomodoroSessionsQueryHandler 
    : IRequestHandler<GetAllPomodoroSessionsQuery, List<PomodoroSession>>
{
    private readonly IPomodoroSessionRepository _repository;

    public GetAllPomodoroSessionsQueryHandler(IPomodoroSessionRepository repository)
        => _repository = repository;

    public async Task<List<PomodoroSession>> Handle(GetAllPomodoroSessionsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}