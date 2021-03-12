using Microsoft.EntityFrameworkCore;
using WorkTimeNoteCommon;
using WorkTimeNoteDataBase.MapConfigurations;
using WorkTimeNoteDataBase.TableMaps.TimeNotes;
using WorkTimeNoteDomain.Entities;

namespace WorkTimeNoteDataBase
{
    public class WorkTimeNoteDbContext : DbContext
    {
        public virtual DbSet<TimeNote> TimeNotes { get; set; }

        public WorkTimeNoteDbContext(DbContextOptions<WorkTimeNoteDbContext> options)
            : base(options)
        {
        }

        public WorkTimeNoteDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.DatabaseConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddConfiguration(new TimeNoteMap());
        }
    }
}
