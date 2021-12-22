namespace RaceApp.Api.Models;

public class TimeRecord : Entity
{
    public DateTime? DrivenOnDate { get; set; }
    public TimeOnly? Time { get; set; }
    public Driver? Driver { get; set; }
    public Track? Track { get; set; }

}
