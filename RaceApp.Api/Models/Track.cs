namespace RaceApp.Api.Models;

public class Track : Entity
{
    public string? Name { get; set; }
    public double Length { get; set; }
    public int Turns { get; set; }
}
