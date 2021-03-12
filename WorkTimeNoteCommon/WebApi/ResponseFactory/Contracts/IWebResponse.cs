using System.Net;

namespace WorkTimeNoteCommon.WebApi.ResponseFactory.Contracts
{
    public interface IWebResponse
    {
        object Body { get; set; }

        string Message { get; set; }

        HttpStatusCode StatusCode { get; set; }
    }
}
