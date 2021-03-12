using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTimeNoteDomain.Entities;

namespace WorkTimeNoteDataBase.MapConfigurations
{
    public abstract class EntityBaseMap<T> : EntityTypeConfiguration<T> where T : EntityBase
    {
        public override void Map(EntityTypeBuilder<T> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Created).HasDefaultValueSql("getutcdate()");

            entity.Property(e => e.Deleted).HasDefaultValueSql("0");

            entity.Property(e => e.NetId)
                .HasColumnName("NetID")
                .HasDefaultValueSql("newid()");
        }
    }
}
