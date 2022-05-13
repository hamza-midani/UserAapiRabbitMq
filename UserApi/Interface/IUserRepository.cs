using UserApi.Model;
namespace UserApi.Interface
{
    public interface IUserRepository
    {
        Task<bool> SaveChangesAsync();
        List<User> GetUsers();
        User GetUser(int id);
        User AddUser(User user);
        User UpdateUser(User user);
        void DeleteUser(User user);
    }
}
