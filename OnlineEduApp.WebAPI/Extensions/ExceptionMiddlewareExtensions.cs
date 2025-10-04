using Microsoft.AspNetCore.Diagnostics;
using OnlineEduApp.Core.Entities.Exceptions;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;
using System.Text.Json;

namespace OnlineEduApp.WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        // Hata Varsa ve hatalar switch bloğunda belirtildiği şekilde fırlatılırsa karşılığında belirtilen StatusCode'a setlenecek son olarak da ErrorDetails yapısı içerisinde response dönecek.
                        var statusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        context.Response.StatusCode = statusCode;

                     

                        var response  = CustomResponseDto<NoContentDto>.Fail(statusCode, contextFeature.Error.Message);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    };
                    

                });
            });
        }
    }
}
