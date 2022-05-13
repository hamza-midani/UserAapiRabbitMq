using UserApi.Model;
namespace UserApi.Interface
{
    public interface IEventLogRepository
    {
        List<EventLog> GetEventsLog();
        EventLog GetEventLogLastId();
        EventLog GetEventLog(int id);
        String AddEventLog(EventLog eventLog);
        Task<bool> SaveChangesAsync();
        void DeleteEventLog(EventLog eventLog);
    }
}
