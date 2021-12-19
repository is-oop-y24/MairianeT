using System;
using System.ComponentModel;

namespace Reports.DAL.Entities
{
    public class Change
    {
        public DateTime CreationTime { get; private init; }
        public Guid Id { get; private init; }
        public ChangeType Type { get; private init; }

        public Change()
        {
        }

        public Change(Guid id, ChangeType type)
        {
            CreationTime = DateTime.Now;
            Id = id;
            Type = type;
        }
    }
}