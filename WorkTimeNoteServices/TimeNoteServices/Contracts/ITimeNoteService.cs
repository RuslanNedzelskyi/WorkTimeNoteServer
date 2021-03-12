using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTimeNoteDomain.Entities;

namespace WorkTimeNoteServices.TimeNoteServices.Contracts
{
    public interface ITimeNoteService
    {
        Task<List<TimeNote>> GetAll();

        Task<List<TimeNote>> New(TimeNote timeNote);

        Task<List<TimeNote>> Update(TimeNote timeNote);

        Task<List<TimeNote>> Remove(Guid netId);
    }
}
