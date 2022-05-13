using UserApi.Model;
namespace UserApi.Service
{
    public class EventLogService : BackgroundService
    {
        public readonly ILogger<EventLogService> logger;
        public readonly ApplicationDbContext applicationDbContext;
        HashSet<User> listCreated;
        HashSet<User> listUpdated;
        HashSet<int> listDeleted;
        CancellationToken token;
        EventLog eventLog;

        public EventLogService(IServiceProvider serviceProvider)
        {
            this.applicationDbContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            listCreated = new HashSet<User>();
            listUpdated = new HashSet<User>();
            listDeleted = new HashSet<int>();

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            token = stoppingToken;

            while (!token.IsCancellationRequested)
            {

                eventLog = applicationDbContext.Events.OrderByDescending(e => e.Id).FirstOrDefault();


                if (eventLog.TableModel == "Users")
                {
                    if (eventLog.EventType == "Inserted")
                    {

                        listCreated.Add(applicationDbContext.Users.Find(eventLog.IdModel));
                    }
                    if (eventLog.EventType == "UPDATED")
                    {

                        listUpdated.Add(applicationDbContext.Users.Find(eventLog.IdModel));

                    }
                    if (eventLog.EventType == "DELETED")
                    {

                        listDeleted.Add(eventLog.IdModel);
                    }

                }
                Console.WriteLine("List of user  Created:");
                foreach (var user in listCreated)
                {
                    Console.WriteLine(user.toString());
                }

                Console.WriteLine("List of user  Updated:");
                foreach (var user in listUpdated)
                {
                    Console.WriteLine(user.toString());
                }
                Console.WriteLine("List of user  Deleted:");
                foreach (var user in listDeleted)
                {
                    Console.WriteLine(user);
                }

                await Task.Delay(10000);

            }

        }
    }
}
