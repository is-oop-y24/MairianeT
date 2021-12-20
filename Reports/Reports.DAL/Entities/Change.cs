using System;
using System.ComponentModel;

namespace Reports.DAL.Entities
{
    public class Change
    {
        public DateTime CreationTime { get; private init; }
        public Guid Id { get; private init; }
        public string Comment { get; set; }
        public Guid TaskId { get; set; }

        public Change()
        {
        }

        public Change(Guid taskId, string comment)
        {
            Id = new Guid();
            CreationTime = DateTime.Now;
            TaskId = taskId;
            Comment = comment;
        }
    }
}