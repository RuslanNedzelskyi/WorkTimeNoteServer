using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using WorkTimeNoteDomain.Entities;
using WorkTimeNoteDomain.Repositories.TimeNoteRepositories.Contracts;

namespace WorkTimeNoteDomain.Repositories
{
    public sealed class TimeNoteRepository : ITimeNoteRepository
    {
        private readonly IDbConnection _connection;

        public TimeNoteRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<TimeNote> GetAll() =>
            _connection.Query<TimeNote>(
                "SELECT * FROM [TimeNotes] " +
                "WHERE [TimeNotes].[Deleted] = 0; ").AsList();

        public void New(TimeNote timeNote) =>
            _connection.Execute(
                "INSERT INTO [TimeNotes] ([Name], [Start], [End], [Rate], [Value]) " +
                "VALUES (@Name, @Start, @End, @Rate, @Value); ",
                timeNote);

        public void Remove(Guid netId) =>
            _connection.Execute(
                "UPDATE [TimeNotes] " +
                "SET [Updated] = GETUTCDATE() " +
                ", [Deleted] = 1 " +
                "WHERE [NetID] = @NewId ",
                new { NewId = netId });

        public void Update(TimeNote timeNote) =>
            _connection.Execute(
                "UPDATE [TimeNotes] " +
                "SET [Updated] = GETUTCDATE() " +
                ", [Name] = @Name " +
                ", [Start] = @Start " +
                ", [End] = @End " +
                ", [Value] = @Value " +
                ", [Rate] = @Rate " +
                "WHERE [ID] = @Id ",
                timeNote);
    }
}
