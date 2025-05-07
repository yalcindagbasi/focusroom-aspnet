namespace Domain.Entities;

public class PomodoroSession
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool IsActive => EndTime == null;
    public int DurationInMinutes { get; set; }
}