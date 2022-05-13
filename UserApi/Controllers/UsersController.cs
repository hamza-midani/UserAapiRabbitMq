using UserApi.Model;
using UserApi.Interface;
using Microsoft.AspNetCore.Mvc;
using UserApi.RabbitMq;

namespace UserApi.Controllers
{
   [ApiController]
    public class UsersController : Controller
    {
        private IUserRepository userData;
        private readonly IMessageProducer messagePublisher;
        public UsersController(IUserRepository userData, IMessageProducer messagePublisher)
        {
            this.userData = userData;
            this.messagePublisher = messagePublisher;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetUsers()
        {
            return Ok(userData.GetUsers());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = userData.GetUser(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User Not Found");
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> AddUser(User user)
        {
              userData.AddUser(user);
              await  userData.SaveChangesAsync();
              messagePublisher.SendMessage(user);
              return Ok(user);
        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteUser( int id)
        {
            var user =userData.GetUser(id);
            if(user != null)
            {
                userData.DeleteUser(user);
                messagePublisher.SendMessage(user);
                return Ok("Delete Success");
            }
                
            return Ok("Not Found");
        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateUser(int id, User user )
        {
            var existingUser = userData.GetUser(id);
            if (existingUser != null)
            {
                user.Id = existingUser.Id;
                userData.UpdateUser(user);
                messagePublisher.SendMessage(user);
                return Ok("Update Success");
            }
            return Ok(existingUser);
        }
    }
}
