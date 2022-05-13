using Microsoft.AspNetCore.Mvc;
using UserApi.Interface;
using UserApi.Model; 
namespace UserApi.Controllers
{
    public class EventLogController : Controller
    {
        IEventLogRepository eventLogRepository;
        IUserRepository userRepository;

        public EventLogController(IEventLogRepository eventLogData, IUserRepository userRepository)
        {
            this.eventLogRepository = eventLogData;
            this.userRepository = userRepository;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEventsLog()
        {
            return Ok(eventLogRepository.GetEventsLog());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEventsLog(int id )
        {
            var EventLog= eventLogRepository.GetEventLog(id);
            if (EventLog != null)
            {
                return Ok(EventLog);
            }

            return NotFound("EventLog NOT Found");
        }
    }
}
