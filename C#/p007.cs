/*
    Puzzle 007 - Make this code better
*/

namespace CSharp.Controllers
{
    public class CalculateController : Controller
    {
        public int Calculate(string query){
            //query = "4 6 add"
            var operatür = query.Split(',')[2];
            int result = 0;
            switch (operatür)
            {
                case "add": 
                    var x = query.Split(',')[0];
                    var y = query.Split(',')[1];
                    result = x + y;
                    break;
                case "sub": 
                    var x = query.Split(',')[0];
                    var y = query.Split(',')[1];
                    result = x - y;
                    break;
                case "multi": 
                    var x = query.Split(',')[0];
                    var y = query.Split(',')[1];
                    result = x * y;
                    break;
                case "div":
                    var x = query.Split(',')[0];
                    var y = query.Split(',')[1];
                    result = x / y;
                    break;
                default:
                    var x = query.Split(',')[0];
                    var y = query.Split(',')[1];
                    throw new System.Exception(string.Format("There is not enough computer power kilohertz to compute "+x+operatür+y));
            }
        }
    }
}