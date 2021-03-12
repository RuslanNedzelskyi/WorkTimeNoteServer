using WorkTimeNoteCommon.WebApi.ResponseFactory.Contracts;

namespace WorkTimeNoteCommon.WebApi.ResponseFactory
{
    public sealed class ResponseFactory : IResponseFactory
    {
        public IWebResponse GetSuccessResponse() =>
            new SuccessResponse();

        public IWebResponse GetErrorResponse() =>
            new ErrorResponse();
    }
}
