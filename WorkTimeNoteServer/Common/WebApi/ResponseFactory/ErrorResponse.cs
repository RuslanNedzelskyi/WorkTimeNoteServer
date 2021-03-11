using System.Net;
using WorkTimeNoteServer.Common.WebApi.ResponseFactory.Contracts;

namespace WorkTimeNoteServer.Common.WebApi.ResponseFactory
{
    public sealed class ErrorResponse : IWebResponse
    {
        public object Body { get; set; }

        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
