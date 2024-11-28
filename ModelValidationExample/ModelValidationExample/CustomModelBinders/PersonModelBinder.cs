using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationExample.Models;

namespace ModelValidationExample.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();
            //FirstName and LastName
            if (bindingContext.ValueProvider.GetValue("FirstName").Count() > 0)
            {
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
                if (bindingContext.ValueProvider.GetValue("LastName").Count() > 0)
                {
                    person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            }

            //Email
            if (bindingContext.ValueProvider.GetValue("Email").Count() > 0)
            {
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            }

            //Phone
            if (bindingContext.ValueProvider.GetValue("Phone").Count() > 0)
            {
                person.Phone = bindingContext.ValueProvider.GetValue("Phone").FirstValue;
            }

            //Price
            if (bindingContext.ValueProvider.GetValue("Price").Count() > 0)
            {
                person.Price = Convert.ToDouble(bindingContext.ValueProvider.GetValue("Price").FirstValue);
            }

            //Password
            if (bindingContext.ValueProvider.GetValue("Password").Count() > 0)
            {
                person.Password = bindingContext.ValueProvider.GetValue("Password").FirstValue;
            }

            //ConfirmPassword
            if (bindingContext.ValueProvider.GetValue("ConfirmPassword").Count() > 0)
            {
                person.ConfirmPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstValue;
            }

            //DateOfBirth
            if (bindingContext.ValueProvider.GetValue("DateOfBirth").Count() > 0)
            {
                person.DateOfBirth = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("DateOfBirth").FirstValue);
            }

            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
