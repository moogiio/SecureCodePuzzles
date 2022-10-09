/*
    Puzzle 006 - Untangle this code to be more readable and follow proper programming techniques.
*/

namespace CSharp.Controllers
{
    public class AdminController : Controller
    {
        public void SeeAdminPanel(){
            if(UserHasValidatedAccount()){
                if(UserIsLoggedIn()){
                    if(UserIsAdmin()){
                        Redirect("/adminpanel");
                    }else{
                        Console.WriteLine("User is not admin");
                    }
                }else{
                    Console.WriteLine("User is not logged in");
                }
            }else{
                Console.WriteLine("User has not clicked on the validation code in email");
            }
        }
    }
}