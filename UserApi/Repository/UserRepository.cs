using UserApi.Interface;
using UserApi.Model;
namespace UserApi.Repository
{
    public class UserRepository : IUserRepository
    {
        public ApplicationDbContext _context { get; }
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public User AddUser(User user)
        {
            user.Id = user.Id;
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.Cin = user.Cin;
                existingUser.Email = user.Email;
                existingUser.Id = user.Id;
                existingUser.Firstname = user.Firstname;
                existingUser.Password = user.Password;
                existingUser.Lastname = user.Lastname;
                _context.Users.Update(existingUser);
                _context.SaveChanges();
            }
            return user;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >0;
        }
    }
}

