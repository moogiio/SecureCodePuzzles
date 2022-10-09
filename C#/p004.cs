/*
    Puzzle 004 - Find the errors
*/

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

        public object GetUser(object query){
            return FindUserInDatabase(query);
        }

        public UserModel GetUser(User user){
            var u = FindUserInDatabase(user);
            if(u != null){
                return u as UserModel;
            }
            return new UserModel();
        }
        
        protected object FindUserInDatabase(object query){
            return _userRepository.FindUser(query);
        }
    }
}
