using System;
using System.Collections.Generic;
using WorkTimeNoteDomain.Entities;

namespace WorkTimeNoteDomain.Repositories.TimeNoteRepositories.Contracts
{
    public interface ITimeNoteRepository
    {
        List<TimeNote> GetAll();

        void New(TimeNote timeNote);

        void Remove(Guid netId);

        void Update(TimeNote timeNote);
    }
}
