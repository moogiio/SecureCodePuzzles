/*
    Puzzle 009 - How can a broken record, play beautiful melodies?
*/

namespace CSharp.Controllers
{
    [Authorize(Role = "Customer")]
    public class BrokenController : Controller
    {
        public BrokenController(DbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IHttpActionResult GetBrokenRecord(int id)
        {
            var userRecord = _db.Records.FirstOrDefault((record) => record.Id == id);
            if (userRecord == null)
            {
                return NotFound();
            }
            return Ok(userRecord);
        }
    }
}