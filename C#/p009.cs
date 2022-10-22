/*
    Puzzle 009 - How can a broken record, play beautiful melodies?
*/

namespace CSharp.Controllers
{
    [Authorize(Role = "Customer")]
    public class BrokenController : Controller
    {
        [HttpGet]
        public IHttpActionResult GetBrokenRecord(int id)
        {
            var record = records.FirstOrDefault((p) => p.Id == id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
    }
}