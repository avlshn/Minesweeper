using Microsoft.AspNetCore.Http;
using Minesweeper.Core.Exceptions;
using Minesweeper.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MinesweeperApi.Exceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            Exception ex)
        {
            Console.WriteLine(ex.Message);

            HttpStatusCode status;
            string message = "";

            var exceptionType = ex.GetType();

            if (exceptionType == typeof(KeyNotFoundException)) 
            {
                message = ex.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(ArgumentOutOfRangeException)) 
            {
                message = ex.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(GameCompletedException))
            {
                message = ex.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(GameCompletedException))
            {
                message = ex.Message;
                status = HttpStatusCode.BadRequest;
            }
            else
            {
                message = ex.Message;
                status = HttpStatusCode.InternalServerError;
            }

            var exceptionResult = JsonSerializer.Serialize(new { error = message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            await context.Response.WriteAsync(exceptionResult).ConfigureAwait(false);

        }

    }
}
