using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTimeNoteDataBase.MapConfigurations;
using WorkTimeNoteDomain.Entities;

namespace WorkTimeNoteDataBase.TableMaps.TimeNotes
{
    public sealed class TimeNoteMap : EntityBaseMap<TimeNote>
    {
        public override void Map(EntityTypeBuilder<TimeNote> entity)
        {
            base.Map(entity);

            entity.ToTable("TimeNotes");

            entity.Property(e => e.Name).HasMaxLength(250);
        }
    }
}
