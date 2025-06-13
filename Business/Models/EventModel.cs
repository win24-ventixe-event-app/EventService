using System;

namespace Business.Models;

public class EventModel
{
    public string Id { get; set; } = null!;
    public string? Name { get; set; }
    public string? Image { get; set; }
    public DateTime EventDate { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
}
