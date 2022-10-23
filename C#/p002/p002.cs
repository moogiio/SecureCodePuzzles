/*
    Puzzle 002 - Find potential errors, and why this code is prone to Cross-Site Scripting attacks.

    p002.html is only used to grasp the context and is not used in the answer.
*/

namespace CSharp.Controllers
{
    [Route("api/search")]
    public class SearchController : Controller
    {

        private readonly DbContext _db;
        public SearchController(DbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public SearchDTO Search(string query)
        {
            /*
                client input 'query' have been checked and was sanitized before it was used as a db search query
            */
            var cleanQuery = SanitizeInput(query);
            var search = new SearchDTO(){
                Query = query
            };

            try{
                search.Items = _db.FindItems(cleanQuery); //Returns list of found items or empty list
            }catch(Exception e){
                throw e;
            }

            return search;
        }
    }

    public class SearchDTO{
        public string Query;
        public List<Item> Items;
    }
}

