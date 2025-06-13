
namespace Business.Models;

public class CreateEventRequest
{
    public string? Name { get; set; }
    public string? Image { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }

}
