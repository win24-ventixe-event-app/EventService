
using Business.Interfaces;
using Business.Models;
using Persistence.Entities;
using Persistence.Interfaces;

namespace Business.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<EventResult> CreateEventAsync(CreateEventRequest request)

    {
        try
        {
            var eventEntity = new EventEntity
            {
                Name = request.Name,
                Image = request.Image,
                EventDate = request.EventDate,
                Description = request.Description,
                Location = request.Location
            };

            var result = await _eventRepository.AddAsync(eventEntity);

            if (result.Success)
            {
                return new EventResult
                {
                    Success = true,
                    Message = "Event created successfully."
                };
            }

            return new EventResult
            {
                Success = false,
                Message = result.ErrorMessage ?? "Failed to create event."
            };
        }
        catch (Exception ex)
        {
            return new EventResult
            {
                Success = false,
                Message = ex.Message
            };
        }
    }

    public async Task<EventResult<IEnumerable<EventModel>>> GetEventAsync()
    {
        var result = await _eventRepository.GetAllAsync();
        var events = result.Result?.Select(x => new EventModel
        {
            Image = x.Image,
            Name = x.Name,
            EventDate = x.EventDate,
            Description = x.Description,
            Location = x.Location
        });

        return new EventResult<IEnumerable<EventModel>>
        {
            Success = result.Success,
            Message = result.ErrorMessage ?? "Events retrieved successfully.",
            Result = events
        };

    }

    public async Task<EventResult<EventModel?>> GetEventAsync(string eventId)
    {
        var result = await _eventRepository.GetAsync(x => x.Id == eventId);
        if (result.Success && result.Result != null)
        {
            var currentEventModel = new EventModel
            {

                Image = result.Result.Image,
                Name = result.Result.Name,
                EventDate = result.Result.EventDate,
                Description = result.Result.Description,
                Location = result.Result.Location

                
                
            };
            return new EventResult<EventModel?>
            {
                Success = true,
                Message = "Event retrieved successfully.",
                Result = currentEventModel
            };
        }
        else
        {
            return new EventResult<EventModel?>
            {
                Success = false,
                Message = result.ErrorMessage ?? "Failed to retrieve event.",
                Result = null
            };
        }

    }

    public Task<EventResult<IEnumerable<EventModel>>> GetEventsAsync()
    {
        throw new NotImplementedException();
    }
}
