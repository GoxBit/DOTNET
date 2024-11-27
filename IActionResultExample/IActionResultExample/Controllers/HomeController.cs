using Microsoft.AspNetCore.Mvc;
using IActionResultExample.Models;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid}/{isloggedin}")]
        public IActionResult Index(int? bookid, bool isloggedin, Book book)
        {
            if (bookid.HasValue == false)//if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied");
                //return new BadRequestResult();
                return BadRequest("Book id is not supplied");
            }
            //if(bookid <= 0)//if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            //{
            //    //Response.StatusCode = 400;
            //    //return Content("Book id cant ve null or empty");
            //    return BadRequest("Book id cant ve null or empty");
            //}

            //int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);

            if (bookid <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id cant be less or equal to zero");
                return BadRequest("Book id cant be less or equal to zero");
            }

            if (bookid > 1000)
            {
                //Response.StatusCode = 400;
                //return Content("Book id cant be greater than 1000");
                return NotFound("Book id cant be greater than 1000");
            }

            if(isloggedin == false)//if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                //Response.StatusCode = 401;
                //return Content("user must be authenticated");
                return Unauthorized("user must be authenticated");
            }

            //return File("/sample.pdf","application/pdf");
            //return new RedirectToActionResult("Books","Store",new {});
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId });
            //return new RedirectToActionResult("Books", "Store", new { }, permanent:true);

            //return new LocalRedirectResult($"store/books/{bookId}", true);
            //return LocalRedirectPermanent($"store/books/{bookId}");
            //return Redirect($"store/books/{bookId}");
            //return RedirectPermanent($"store/books/{bookid}");
            return Content($"<h1>Book Id: {book.BookId}</br>Author: {book.Author}</h1>", "text/html");
        }
    }
}
