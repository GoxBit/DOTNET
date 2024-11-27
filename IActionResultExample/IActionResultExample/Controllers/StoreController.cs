using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{id}")]
        public IActionResult Books()
        {
            int bookid = Convert.ToInt16(Request.RouteValues["id"]);
            return Content($"<h1>Books Store {bookid}</h1>","text/html");
        }
    }
}
