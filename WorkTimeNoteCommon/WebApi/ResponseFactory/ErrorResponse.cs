using System.Net;
using WorkTimeNoteCommon.WebApi.ResponseFactory.Contracts;

namespace WorkTimeNoteCommon.WebApi.ResponseFactory
{
    public sealed class ErrorResponse : IWebResponse
    {
        public object Body { get; set; }

        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
