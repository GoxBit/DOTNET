using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            return Content("Hello from index", "text/plain");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Luis",
                LastName = "Duran",
                Age = 25
            };
            //return new JsonResult(person);
            return Json(person);
        }

        [Route("contact/{demo:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from Contact";
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            //return new VirtualFileResult("/sample.pdf", "application/pdf");
            return File("/sample.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            //return new PhysicalFileResult(@"C:\Users\gox\source\repos\ControllersExample\ControllersExample\wwwroot\sample.pdf", "application/pdf");//for files out of wwwroot
            return PhysicalFile(@"C:\Users\gox\source\repos\ControllersExample\ControllersExample\wwwroot\sample.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\gox\source\repos\ControllersExample\ControllersExample\wwwroot\sample.pdf");

            //return new FileContentResult(bytes, "application/pdf");//useful when you wnat to encryp data in file
            return File(bytes, "application/pdf");
        }
    }
}
