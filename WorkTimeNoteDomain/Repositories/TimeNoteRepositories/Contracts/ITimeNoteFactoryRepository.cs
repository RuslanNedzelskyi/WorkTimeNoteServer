using System.Data;

namespace WorkTimeNoteDomain.Repositories.TimeNoteRepositories.Contracts
{
    public interface ITimeNoteFactoryRepository
    {
        ITimeNoteRepository NewTimeNoteRepository(IDbConnection connection);
    }
}
