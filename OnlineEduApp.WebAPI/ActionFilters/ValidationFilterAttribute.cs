using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.WebAPI.ActionFilters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];

            // Methoda parametre olarak gönderilen DTO'yu bulalım.
            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

            // The parameter is null check !

            if (param == null)
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, $"Parametre olarak gönderilmesi gereken Object Null değer içeriyor. Controller : {controller}"));

            // The parameter is validation check !
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                context.Result = new UnprocessableEntityObjectResult(CustomResponseDto<NoContentDto>.Fail(422,errors));
            }
        }
    }
}
