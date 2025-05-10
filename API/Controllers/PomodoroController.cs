using Application.Commands;
using Application.Queries;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PomodoroController : ControllerBase
{
    private readonly IMediator _mediator;

    public PomodoroController(IMediator mediator) => _mediator = mediator;
    public class StartPomodoroRequest
    {
        public int DurationInMinutes { get; set; }
    } 
    [HttpPost("start")]
    public async Task<IActionResult> StartPomodoro([FromBody] StartPomodoroRequest request)
    {
        var sessionId = await _mediator.Send(new StartPomodoroCommand(request.DurationInMinutes));
        return Ok(sessionId);
    }
    [HttpPost("stop/{sessionId}")]
    public async Task<IActionResult> StopPomodoro(Guid sessionId)
    {
        await _mediator.Send(new StopPomodoroCommand(sessionId));
        return NoContent();
    }
    [HttpGet("sessions")]
    public async Task<IActionResult> GetAllSessions()
    {
        var sessions = await _mediator.Send(new GetAllPomodoroSessionsQuery());
        return Ok(sessions);
    }
}
