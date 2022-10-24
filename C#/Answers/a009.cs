namespace CSharp.Controllers
{
    [Authorize(Role = "Customer")]
    public class BrokenController : Controller
    {
        [HttpGet]
        public IHttpActionResult GetBrokenRecord(int id)
        {
            var record = records.FirstOrDefault((p) => p.Id == id && p.OwnerId == User.Id); // Here we add a condition so that the authorized user only gets to see its own records.
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
    }
}