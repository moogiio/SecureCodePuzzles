using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CSharp.Controllers
{
    [Route("api")]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public UserController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        /*
            Did not correctly declare types for the input parameter and return value
        */
        public object GetUser(object query){ 
            return FindUserInDatabase(query);
        }

        /*
            Fails to return a user, or a empty user object becouse of beeing a void method.
        */
        public void GetUser(User user){
            var u = FindUserInDatabase(user);
            if(u != null){
                return u as UserModel;
            }
        }
        
        /*
            A repository should always return a complex type object, such as a User or UserModel class. 
        */
        protected object FindUserInDatabase(object query){
            return _userRepository.FindUser(query);
        }
    }
}
