using System;
using System.ComponentModel;

namespace Reports.DAL.Entities
{
    public class Change
    {
        public string CreationTime { get; private init; }
        public Guid Id { get; private init; }
        public string Comment { get; set; }
        public Guid TaskId { get; set; }

        public Change()
        {
        }

        public Change(Guid taskId, string comment, string time)
        {
            Id = new Guid();
            CreationTime = time;
            TaskId = taskId;
            Comment = comment;
        }
    }
}