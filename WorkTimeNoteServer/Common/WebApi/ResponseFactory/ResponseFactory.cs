using WorkTimeNoteServer.Common.WebApi.ResponseFactory.Contracts;

namespace WorkTimeNoteServer.Common.WebApi.ResponseFactory
{
    public sealed class ResponseFactory : IResponseFactory
    {
        public IWebResponse GetSuccessResponse() =>
            new SuccessResponse();

        public IWebResponse GetErrorResponse() =>
            new ErrorResponse();
    }
}
