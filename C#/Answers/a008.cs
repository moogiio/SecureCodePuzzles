namespace CSharp.Controllers
{
    [Route("api/search")]
    public class SearchController : Controller
    {
        public bool CreateUser(UserDTO user)
        {
            try
            {
                /*do stuff*/
                _db.Users.Add(UserDTO.ConvertToUser());
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
                /*SaveChanges() will throw validation exception if rules are not met*/
            }
            
        }
    }

    public class UserDTO{
        [Required]
        [StringLength(24, MinimumLength = 3, ErrorMessage = "Username must be between 4 and 24 characters in length.")]
        [RegularExpression(@"[^A-Za-z0-9]+")]
        public string Username { get; set; }
        [Required]
        [StringLength(4096, MinimumLength = 14, ErrorMessage = "Password must be at least 14 characters in length.")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$")]
        public string Email { get; set; }
    }
}
