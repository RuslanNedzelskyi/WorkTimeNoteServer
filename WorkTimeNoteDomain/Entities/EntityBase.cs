using System;

namespace WorkTimeNoteDomain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; set; }

        public Guid NetId { get; set; } = new Guid();

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime? Updated { get; set; }

        public bool Deleted { get; set; }

        public bool IsNew() =>
            Id.Equals(0);
    }
}
