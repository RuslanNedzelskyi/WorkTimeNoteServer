using System.Net;

namespace WorkTimeNoteServer.Common.WebApi.ResponseFactory.Contracts
{
    public interface IWebResponse
    {
        object Body { get; set; }

        string Message { get; set; }

        HttpStatusCode StatusCode { get; set; }
    }
}
