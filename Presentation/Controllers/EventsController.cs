using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController(IEventService eventService) : ControllerBase
    {
        private readonly IEventService _eventService = eventService;

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _eventService.CreateEventAsync(request);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _eventService.GetEventsAsync();
            if (result.Success)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var currentEvent = await _eventService.GetEventAsync(id);
            if (currentEvent.Success)
            {
                return Ok(currentEvent.Result);
            }
            return NotFound(currentEvent.Message);
        }
    }
}
