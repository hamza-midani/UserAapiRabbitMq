using UserApi.Interface;
using UserApi.Model;

namespace UserApi.Repository
{
    public class EventLogRepository : IEventLogRepository
    {
        private ApplicationDbContext applicationDbContext;
        public EventLogRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;

        }
        public String AddEventLog(EventLog eventLog)
        {
            eventLog.Id = eventLog.Id;
            applicationDbContext.Events.Add(eventLog);
            applicationDbContext.SaveChanges();
            applicationDbContext.SaveChanges();
            return "OK";
        }
        public void DeleteEventLog(EventLog eventLog)
        {
            applicationDbContext.Events.Remove(eventLog);
            applicationDbContext.SaveChanges();
        }
        public EventLog GetEventLog(int id)
        {
            var eventLog = applicationDbContext.Events.Find(id);
            return eventLog;
        }
        public EventLog GetEventLogLastId()
        {
            var eventLog = applicationDbContext.Events.Last();
            return eventLog;
        }
        public List<EventLog> GetEventsLog()
        {
            return applicationDbContext.Events.ToList();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}
