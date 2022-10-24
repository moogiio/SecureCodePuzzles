namespace CSharp.Controllers
{
    public class UserController : Controller
    {
        /*
            Let's a logged in user look at another users profile
        */
        [HttpGet]
        [Authorize]
        public IHttpActionResult<UserDTO> GetUserProfile(string username)
        {
            UserProfile uProfile = db.Users.FirstOrDefault((p) => p.Username == username);
            if (uProfile == null)
            {
                return NotFound();
            }
            UserDTO userDto = uProfile.ToUserDTO();
            return Ok(userDto);
        }
    }

    /* This class corresponds with the database table 'User' and should only be used internally, and not sent out to any clients*/
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

    /* A DTO should be used to filter out and controll the flow of what data goes where */
    public class UserProfileDTO{
        public string Username { get; set; }
        public string Homepage { get; set; }
    }
}
