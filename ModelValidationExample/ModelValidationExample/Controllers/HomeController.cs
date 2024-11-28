using Microsoft.AspNetCore.Mvc;
using ModelValidationExample.CustomModelBinders;
using ModelValidationExample.Models;

namespace ModelValidationExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        //[Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))]
        //[ModelBinder(BinderType = typeof(PersonModelBinder))]
        //[FromBody]
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));

                return BadRequest(errors);
            }
            return Content($"{person}, {UserAgent}");
        }
    }
}
