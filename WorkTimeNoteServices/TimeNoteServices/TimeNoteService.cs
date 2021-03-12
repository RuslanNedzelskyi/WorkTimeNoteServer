using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WorkTimeNoteDomain.DbConnectionFactory.Contracts;
using WorkTimeNoteDomain.Entities;
using WorkTimeNoteDomain.Repositories.TimeNoteRepositories.Contracts;
using WorkTimeNoteServices.TimeNoteServices.Contracts;

namespace WorkTimeNoteServices.TimeNoteServices
{
    public class TimeNoteService : ITimeNoteService
    {
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly ITimeNoteFactoryRepository _timeNoteFactoryRepository;

        public TimeNoteService(
            IDbConnectionFactory connectionFactory,
            ITimeNoteFactoryRepository timeNoteFactoryRepository)
        {
            _connectionFactory = connectionFactory;
            _timeNoteFactoryRepository = timeNoteFactoryRepository;
        }

        public Task<List<TimeNote>> GetAll() =>
            Task.Run(() =>
            {
                using (IDbConnection connection = _connectionFactory.NewSqlConnection())
                {
                    return _timeNoteFactoryRepository
                                .NewTimeNoteRepository(connection)
                                    .GetAll();
                }
            });

        public Task<List<TimeNote>> New(TimeNote timeNote) =>
            Task.Run(() =>
            {
                using (IDbConnection connection = _connectionFactory.NewSqlConnection())
                {
                    ITimeNoteRepository timeNoteRepository = _timeNoteFactoryRepository
                                .NewTimeNoteRepository(connection);

                    TimeSpan span = timeNote.End.Subtract(timeNote.Start);

                    if (span.Hours < 0)
                        throw new Exception();

                    timeNote.Value = span.Hours * timeNote.Rate;

                    timeNoteRepository.New(timeNote);

                    return timeNoteRepository.GetAll();
                }
            });

        public Task<List<TimeNote>> Remove(Guid netId) =>
            Task.Run(() =>
            {
                using (IDbConnection connection = _connectionFactory.NewSqlConnection())
                {
                    ITimeNoteRepository timeNoteRepository = _timeNoteFactoryRepository
                                .NewTimeNoteRepository(connection);

                    timeNoteRepository.Remove(netId);

                    return timeNoteRepository.GetAll();
                }
            });

        public Task<List<TimeNote>> Update(TimeNote timeNote) =>
            Task.Run(() =>
            {
                using (IDbConnection connection = _connectionFactory.NewSqlConnection())
                {
                    ITimeNoteRepository timeNoteRepository = _timeNoteFactoryRepository
                                .NewTimeNoteRepository(connection);

                    TimeSpan span = timeNote.End.Subtract(timeNote.Start);

                    if (span.Hours < 0)
                        throw new Exception();

                    timeNote.Value = span.Hours * timeNote.Rate;

                    timeNoteRepository.Update(timeNote);

                    return timeNoteRepository.GetAll();
                }
            });
    }
}
