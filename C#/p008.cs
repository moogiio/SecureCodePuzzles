/*
    Puzzle 008 - Blacklist improvements
*/

namespace CSharp.Controllers
{
    [Route("api/search")]
    public class SearchController : Controller
    {
        List<char> _illegalCharacters = {',','.','-',';',':','<','>','/','&','\\','?','!','\"','#','¤','$','%','(',')','{','}','[',']'};
        int _minimumLength = 4;
        int _maximumLength = 14;
        string _emailRegex = @"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        public bool CreateUser(UserDTO user)
        {
            var isUserValid = checkUserData(user);
            if(!isUserValid){
                return false;
            }else{
            /*
                do stuff, save to db etc.
            */
                return true;
            }
        }

        private bool checkUserData(UserDTO user){
            var isUserValid = false;
            // Check so that username does not contain any illegal characters
            if(user.Username.Contains(_illegalCharacters)){
                isUserValid = !isUserValid;
            }
            // Check so that password does not caintain any illegal characters
            if(user.Password.Contains(_illegalCharacters) || user.Password.Length > _maximumLength || user.Password.Length < _minimumLength){
                isUserValid = !isUserValid;
            }
            // Check so that email address is valid
            Regex rg = new Regex(_emailRegex);
            MatchCollection emailMatches = rg.Matches(user.Email); 
            if(emailMatches.Count > 1 || emailMatches.Count < 1){
                isUserValid = !isUserValid;
            }

            return isUserValid;
        }
    }

    public class UserDTO{
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
