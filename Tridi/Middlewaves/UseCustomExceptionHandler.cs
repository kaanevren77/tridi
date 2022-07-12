using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using Tridi.Data.Dto;
using Tridi.Data.Exceptions;

namespace Tridi.Middlewaves
{
    public static class UseCustomExceptionHandler
    {

        public static void UserCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                //turn back here

                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    //error type (client or server)
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500
                    };

                    // set response
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<object>.Fail(statusCode, exceptionFeature.Error.Message);

                    // serialize response and write
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });

            });

        }

    }
}
