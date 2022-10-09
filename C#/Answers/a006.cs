namespace CSharp.Controllers
{
    public class AdminController : Controller
    {
        /*
            This is the Guard Clause Technique
        */
        public void SeeAdminPanel(){
            if(!UserHasValidatedAccount()){
                Console.WriteLine("User has not clicked on the validation code in email");
                return;
            }
            if(!UserIsLoggedIn()){
                Console.WriteLine("User is not logged in");
                return;
            }
            if(!UserIsAdmin()){
                Console.WriteLine("User is not admin");
                return;
            }
            Redirect("/adminpanel");
        }
    }
}