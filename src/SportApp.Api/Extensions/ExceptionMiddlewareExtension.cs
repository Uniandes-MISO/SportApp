//using Microsoft.AspNetCore.Diagnostics;
//using SportApp.Api.Models;
//using SportApp.Core.Interfaces;
//using System.Net;

//namespace SportApp.Api.Extensions
//{
//    public static class ExceptionMiddlewareExtension
//    {
//        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
//        {
//            app.UseExceptionHandler(
//                appError =>
//                {
//                    appError.Run(async context =>
//                    {
//                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                        context.Response.ContentType = "application/json";

//                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
//                        if (contextFeature != null)
//                        {
//                            //logger.LogError($"Something went wrong: {contextFeature.Error}");
//                            await context.Response.WriteAsync(
//                                new ResponseModel()
//                                {
//                                    Status = context.Response.StatusCode.ToString(),
//                                    Message = "Internal Server Error."
//                                }.ToString());
//                        }
//                    });
//                });
//        }
//    }
//}