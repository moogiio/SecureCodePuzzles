namespace CSharp.Controllers
{
    [Route("api/search")]
    public class SearchController : Controller
    {

        private readonly IConfiguration _configuration;
        public SearchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public SearchDTO Search(string query)
        {
            /*
                client input 'query' is checked and sanitized before used in a db search query
            */
            var cleanQuery = SanitizeInput(query);
            var search = new SearchDTO(){
                Query: query
            }
            try{
                search.Items = _db.FindItems(cleanQuery);
            }

            return search;
        }
    }

    public class SearchDTO(){
        public string Query;
        public List<Item> Items;
    }
}

