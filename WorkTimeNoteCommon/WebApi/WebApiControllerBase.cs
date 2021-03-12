using Microsoft.AspNetCore.Mvc;
using System.Net;
using WorkTimeNoteCommon.WebApi.ResponseFactory.Contracts;

namespace WorkTimeNoteCommon.WebApi
{
    public abstract class WebApiControllerBase : Controller
    {
        private readonly IResponseFactory _responseFactory;

        protected WebApiControllerBase(IResponseFactory responseFactory)
        {
            _responseFactory = responseFactory;
        }

        protected IWebResponse SuccessResponseBody(object body, string message = "")
        {
            IWebResponse response = _responseFactory.GetSuccessResponse();

            response.Body = body;
            response.StatusCode = HttpStatusCode.OK;
            response.Message = message;

            return response;
        }

        protected IWebResponse ErrorResponseBody(string message, HttpStatusCode statusCode)
        {
            IWebResponse response = _responseFactory.GetErrorResponse();

            response.Message = message;
            response.StatusCode = statusCode;

            return response;
        }
    }
}
