using System;
using Business.Models;

namespace Business.Interfaces;

public interface IEventService
{
    Task<EventResult> CreateEventAsync(CreateEventRequest request);
    Task<EventResult<IEnumerable<EventModel>>> GetEventsAsync();
    Task<EventResult<EventModel?>> GetEventAsync(string id);
}
