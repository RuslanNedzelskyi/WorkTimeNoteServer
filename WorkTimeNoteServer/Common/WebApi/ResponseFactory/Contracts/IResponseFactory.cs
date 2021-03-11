namespace WorkTimeNoteServer.Common.WebApi.ResponseFactory.Contracts
{
    public interface IResponseFactory
    {
        IWebResponse GetSuccessResponse();

        IWebResponse GetErrorResponse();
    }
}
