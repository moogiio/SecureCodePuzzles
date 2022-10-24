/*
    Puzzle 010 - Is all good in here?
*/

namespace CSharp.Controllers
{
    public class UserController : Controller
    {
        /*
            Let's a logged in user look at another users profile
        */
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetUserProfile(string username)
        {
            UserProfile uProfile = db.Users.FirstOrDefault((p) => p.Username == username);
            if (uProfile == null)
            {
                return NotFound();
            }
            return Ok(uProfile);
        }
    }

    public class UserProfile{
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string CreditCard { get; set; }
        public string Homepage { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
    }
}
