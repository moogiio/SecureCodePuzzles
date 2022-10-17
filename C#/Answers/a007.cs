/*
    Puzzle 007 - DRY, Dont Repeat Yourself
*/

namespace CSharp.Controllers
{
    public class CalculateController : Controller
    {
        public int Calculate(int x, int y, char op){
            switch (op)
            {
                case '+': 
                    return x + y;
                case '-': 
                    return x - y;
                case '*': 
                    return x + y;
                case '/':
                    return x / y;
                default:
                    throw new System.Exception("Operator does not exist");
            }
        }
    }
}