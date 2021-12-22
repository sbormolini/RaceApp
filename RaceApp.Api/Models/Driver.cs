namespace RaceApp.Api.Models;

public class Driver : Entity
{
    /// <summary>
    /// Driver name
    /// </summary>
    /// <example>Grocery</example>
    public string? Name { get; set; }

    /// <summary>
    /// Driver Description
    /// </summary>
    /// <example>Pick Bread</example>
    public string? Nationality { get; set; }

    /// <summary>
    /// Driver category
    /// </summary>
    /// <example>Amateur</example>
    public string? Category { get; set; }
}