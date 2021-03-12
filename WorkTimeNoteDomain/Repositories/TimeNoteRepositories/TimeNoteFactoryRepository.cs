using System.Data;
using WorkTimeNoteDomain.Repositories.TimeNoteRepositories.Contracts;

namespace WorkTimeNoteDomain.Repositories.TimeNoteRepositories
{
    public sealed class TimeNoteFactoryRepository : ITimeNoteFactoryRepository
    {
        public ITimeNoteRepository NewTimeNoteRepository(IDbConnection connection) =>
            new TimeNoteRepository(connection);
    }
}
