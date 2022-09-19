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

        public void GetUser(User user){
            var u = FindUserInDatabase(user);
            if(u != null){
                return u as UserModel;
            }
        }
        
        protected object FindUserInDatabase(object query){
            return _userRepository.FindUser(query);
        }
    }
}
