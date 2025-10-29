

using System.Net;
using System.Runtime.CompilerServices;
using Communication.Responses;
using Exceptions;
using Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.FIlters
{
    public class ExceptionFilter : IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext context)
        {
            if (context.Exception is MeuLivroDeReceitasException)
                HandleProjectException(context);
            else
                ThrowUnknownException(context);

        }
        private void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErroNaValidacaoException)
            {
                var exception = context.Exception as ErroNaValidacaoException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.MensagensDeErro));
            }
        }

        private void ThrowUnknownException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.Get("UNKNOWN_ERROR")));
        }
    }

}
