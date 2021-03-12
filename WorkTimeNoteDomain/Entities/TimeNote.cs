using System;

namespace WorkTimeNoteDomain.Entities
{
    public sealed class TimeNote : EntityBase
    {
        public string Name { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public decimal Rate { get; set; }

        public decimal Value { get; set; }
    }
}
